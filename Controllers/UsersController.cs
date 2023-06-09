using BookLibraryAPI.Data;
using BookLibraryAPI.Models.Domain;
using BookLibraryAPI.Models.DTO;
using BookLibraryAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BooklibraryContext _context;
        private readonly IUserRepository _userRepository;
        public UsersController(BooklibraryContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var allUsers = _userRepository.GetAllUser();
            return Ok(allUsers);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var userWirhIdDTO = _userRepository.GetUserById(id);
            return Ok(userWirhIdDTO);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateUserById(int id, UserNoIdDTO userDTO)
        {
            var updateUser = _userRepository.UpdateUserById(id, userDTO);
            return Ok(updateUser);

        }
            

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost()]
        public IActionResult AddUser(UserNoIdDTO userDTO)
        {
            try
            {
                if (!ValidateAddUser(userDTO))
                {
                    return BadRequest(ModelState);
                }
                if (ModelState.IsValid)
                {
                    var addUser = _userRepository.AddUser(userDTO);
                    return Ok(addUser);
                }
                else return BadRequest(ModelState);
            }
            catch (Exception e) { return BadRequest(e); }
            
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize]

        public IActionResult DeleteUserById(int id)
        {
            var deleteUser = _userRepository.DeleteById(id);
            return Ok(deleteUser);
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #region Private methods
        private bool ValidateAddUser(UserNoIdDTO user)
        {
            if (user == null)
            {
                ModelState.AddModelError(nameof(user), $"Please add book data");


                return false;
            }
            // kiem tra Description NotNull
            if (string.IsNullOrEmpty(user.Username))
            {
                ModelState.AddModelError(nameof(user.Username),
                $"{nameof(user.Username)} cannot be null");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError(nameof(user.Password),
                $"{nameof(user.Password)} cannot be null");
            }
            if (string.IsNullOrEmpty(user.FullName))
            {
                ModelState.AddModelError(nameof(user.FullName),
                $"{nameof(user.FullName)} cannot be null");
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                ModelState.AddModelError(nameof(user.Email),
                $"{nameof(user.Email)} cannot be null");
            }
            if (string.IsNullOrEmpty(user.Sdt))
            {
                ModelState.AddModelError(nameof(user.Sdt),
                $"{nameof(user.Sdt)} cannot be null");
            }
            if (string.IsNullOrEmpty(user.DiaChi))
            {
                ModelState.AddModelError(nameof(user.DiaChi),
                $"{nameof(user.DiaChi)} cannot be null");
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
