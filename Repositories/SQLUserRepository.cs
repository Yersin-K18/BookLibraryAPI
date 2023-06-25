using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
using BookLibraryAPI.Models.DTO;

namespace BookLibraryAPI.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly BooklibraryContext _dbContext;

        public SQLUserRepository(BooklibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserNoIdDTO AddUser(UserNoIdDTO AddUser)
        {
            var userDomainModel = new User
            {
                Username = AddUser.Username,
                Password = AddUser.Password,
                FullName = AddUser.FullName,
                Email = AddUser.Email,
                Sdt = AddUser.Sdt,
                DiaChi  = AddUser.DiaChi,
                MaSoThue = AddUser.MaSoThue,
            };

            _dbContext.Users.Add(userDomainModel);
            _dbContext.SaveChanges();
            return AddUser;
        }

        public User? DeleteById(int id)
        {
            var userDomain = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (userDomain != null)
            {
                _dbContext.Users.Remove(userDomain);
                _dbContext.SaveChanges();
            }
            return null;
        }

        public List<UserDTO> GetAllUser()
        {
            var allUserDomain = _dbContext.Users.Select(User => new UserDTO()
            {
                Id = User.Id,
                Username = User.Username,
                Password = User.Password,
                FullName = User.FullName,
                Email = User.Email,
                Sdt = User.Sdt,
                DiaChi= User.DiaChi,
                MaSoThue= User.MaSoThue,
                Orders = User.Orders.Select(o => o.Id).ToList(),
            }).ToList();
            return allUserDomain;
        }

        public UserDTO GetUserById(int id)
        {
            var userWithDomain = _dbContext.Users.Where(n => n.Id == id);

            var userWithIdDTO = userWithDomain.Select(User => new UserDTO()
            {
                Id  = User.Id,
                Username = User.Username,
                Password = User.Password,
                FullName = User.FullName,
                Email = User.Email,
                Sdt = User.Sdt,
                DiaChi = User.DiaChi,
                MaSoThue = User.MaSoThue,
                Orders = User.Orders.Select(o => o.Id).ToList(),
            }).FirstOrDefault();
            return userWithIdDTO;
        }

        public UserNoIdDTO UpdateUserById(int id, UserNoIdDTO UserDTO)
        {
            var userDomain = _dbContext.Users.FirstOrDefault(n => n.Id == id);

            if(userDomain != null)
            {
                userDomain.Username = UserDTO.Username;
                userDomain.Password = UserDTO.Password;
                userDomain.FullName = UserDTO.FullName;
                userDomain.Email = UserDTO.Email;
                userDomain.Sdt = UserDTO.Sdt;
                userDomain.DiaChi = UserDTO.DiaChi;
                userDomain.MaSoThue = UserDTO.MaSoThue;
                _dbContext.SaveChanges();
            }

            return null;
        }
    }
}
