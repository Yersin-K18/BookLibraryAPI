using BookLibraryAPI.Models;
using BookLibraryAPI.Models.DTO;

namespace BookLibraryAPI.Repositories
{
    public interface IAuthorRepository
    {
        List<AuthorDTO> GetAllAuthor();
        AuthorNoIdDTO GetAuthorById(int id);
        AddAuthorDTO AddAuthor(AddAuthorDTO addAuthorDTO);
        AuthorNoIdDTO? UpdateAuthor(int id, AuthorNoIdDTO authorDTO);
        Author? DeleteAuthorById(int id);
    }
}
