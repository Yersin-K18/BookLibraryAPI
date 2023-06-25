using BookLibraryAPI.Models;
using BookLibraryAPI.Models.DTO;

namespace BookLibraryAPI.Repositories
{
    public interface IUserRepository
    {
        List<UserDTO> GetAllUser();
        UserDTO GetUserById(int id);

        UserNoIdDTO AddUser(UserNoIdDTO AddUser);
        UserNoIdDTO UpdateUserById(int id, UserNoIdDTO UserDTO);
        User? DeleteById(int id);
    }
}
