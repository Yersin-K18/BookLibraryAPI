using BookLibraryAPI.Models.DTO;
using BookLibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using BookLibraryAPI.Models.Domain;

namespace BookLibraryAPI.Repositories
{
    public interface IAuthorRepository
    {
        List<AuthorDTO> GetAllAuthors();
        AuthorDTO GetAuthorById(int id);
        AddAuthorRequestDTO AddAuthor(AddAuthorRequestDTO addAuthorRequestDTO);
        AddAuthorRequestDTO UpdateAuthorById(int id, AddAuthorRequestDTO authorNoIdDTO);
        Author DeleteAuthorById(int id);
    }

    public class AuthorRepository : IAuthorRepository
    {
        private readonly BooklibraryContext _booklibraryContext;


        public AuthorRepository(BooklibraryContext booklibraryContext)
        {
            _booklibraryContext = booklibraryContext;
        }
        public AddAuthorRequestDTO AddAuthor(AddAuthorRequestDTO addAuthorRequestDTO)
        {
            var authorModel = new Author
            {
              Name = addAuthorRequestDTO.Name,
              Nickname = addAuthorRequestDTO.Nickname,
              Description = addAuthorRequestDTO.Description,
              Image = addAuthorRequestDTO.Image,
              SocialLink = addAuthorRequestDTO.SocialLink,             
            };

            _booklibraryContext.Authors.Add(authorModel);
            _booklibraryContext.SaveChanges();
            return addAuthorRequestDTO;
        }

        public Author DeleteAuthorById(int id)
        {
            var AuthorDomain = _booklibraryContext.Authors.FirstOrDefault(c => c.Id == id);
            if (AuthorDomain != null)
            {
                _booklibraryContext.Authors.Remove(AuthorDomain);
                _booklibraryContext.SaveChanges();
            }
            return null;
        }

        public List<AuthorDTO> GetAllAuthors()
        {

            var allAuthorsDomain = _booklibraryContext.Authors.Include(c => c.Products).Select(Author => new AuthorDTO()
            {
                Id = Author.Id,
                Name = Author.Name,
                Nickname = Author.Nickname,
                Description = Author.Description,
                Image = Author.Image,
                SocialLink = Author.SocialLink,
                ProductNames = Author.Products.Select(n => n.Name).ToList()

            }).ToList();
            return allAuthorsDomain;
        }

        public AuthorDTO GetAuthorById(int id)
        {
            var AuthorWithDomain = _booklibraryContext.Authors.Include(c => c.Products)
            .FirstOrDefault(n => n.Id == id);

            var authorIdDTO = new AuthorDTO()
            {
                Id = AuthorWithDomain.Id,
                Name = AuthorWithDomain.Name,
                Nickname = AuthorWithDomain.Nickname,
                Description = AuthorWithDomain.Description,
                Image = AuthorWithDomain.Image,
                SocialLink = AuthorWithDomain.SocialLink,
                ProductNames = AuthorWithDomain.Products.Select(n => n.Name).ToList(),
            };
            return authorIdDTO;
        }

        public AddAuthorRequestDTO UpdateAuthorById(int id, AddAuthorRequestDTO authorNoIdDTO)
        {

            var authorDomain = _booklibraryContext.Authors.FirstOrDefault(c => c.Id == id);

            if (authorDomain != null)
            {
                authorDomain.Name = authorNoIdDTO.Name;
                authorDomain.Nickname = authorNoIdDTO.Nickname;
                authorDomain.Description = authorNoIdDTO.Description;
                authorDomain.Image = authorNoIdDTO.Image;
                authorDomain.SocialLink = authorNoIdDTO.SocialLink;
                _booklibraryContext.SaveChanges();
            }
            return authorNoIdDTO;
        }
    }
}
  