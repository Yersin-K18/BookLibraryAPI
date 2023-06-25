using BookLibraryAPI.Models;
using BookLibraryAPI.Models.DTO;
using System;

namespace BookLibraryAPI.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BooklibraryContext _dbContext;
        public AuthorRepository(BooklibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public AddAuthorDTO AddAuthor(AddAuthorDTO addAuthorDTO)
        {
            var AuthorModels = new Author
            {
               
                Name = addAuthorDTO.Name,
                Nickname= addAuthorDTO.Nickname,
                BooksPublished= addAuthorDTO.BooksPublished,
                Description = addAuthorDTO.Description,
                Image = addAuthorDTO.Image,
                SocialLink = addAuthorDTO.SocialLink,

            };
            //Use Domain Model to create Author
            _dbContext.Authors.Add(AuthorModels);
            _dbContext.SaveChanges();
            return addAuthorDTO;
        }

        public Author? DeleteAuthorById(int id)
        {
            var AuthorModels = _dbContext.Authors.FirstOrDefault(n => n.Id == id);
            if (AuthorModels != null)
            {
                _dbContext.Authors.Remove(AuthorModels);
                _dbContext.SaveChanges();
            }
            return null;
        }

        public List<AuthorDTO> GetAllAuthor()
        {
            var allAuthorModels = _dbContext.Authors.ToList();
            //Map domain models to DTOs
            var allAuthorDTO = new List<AuthorDTO>();
            foreach (var authorModels in allAuthorModels)
            {
                allAuthorDTO.Add(new AuthorDTO()
                {
                    Id = authorModels.Id,
                    Name = authorModels.Name,
                    Nickname = authorModels.Nickname,
                    BooksPublished = authorModels.BooksPublished,
                    Description = authorModels.Description,
                    Image = authorModels.Image,
                    SocialLink = authorModels.SocialLink,
                });
            }
            return allAuthorDTO;
        }

        public AuthorNoIdDTO GetAuthorById(int id)
        {
            var AuthorWithIdModels = _dbContext.Authors.FirstOrDefault(x => x.Id ==
id);
            if (AuthorWithIdModels == null)
            {
                return null;
            }
            //Map Domain Model to DTOs
            var AuthorNoIdDTO = new AuthorNoIdDTO
            {
                Name = AuthorWithIdModels.Name,
                Nickname = AuthorWithIdModels.Nickname,
                BooksPublished = AuthorWithIdModels.BooksPublished,
                Description = AuthorWithIdModels.Description,
                Image = AuthorWithIdModels.Image,
                SocialLink = AuthorWithIdModels.SocialLink,
            };
            return AuthorNoIdDTO;
        }

        public AuthorNoIdDTO? UpdateAuthor(int id, AuthorNoIdDTO authorDTO)
        {
            var AuthorModels = _dbContext.Authors.FirstOrDefault(n => n.Id == id);
            if (AuthorModels != null)
            {
                AuthorModels.Name = AuthorModels.Name;
                AuthorModels.Nickname = AuthorModels.Nickname;
                AuthorModels.BooksPublished = AuthorModels.BooksPublished;
                AuthorModels.Description = AuthorModels.Description;
                AuthorModels.Image = AuthorModels.Image;
                AuthorModels.SocialLink = AuthorModels.SocialLink;
                _dbContext.SaveChanges();
            }
            return authorDTO;
        }
    }
}
