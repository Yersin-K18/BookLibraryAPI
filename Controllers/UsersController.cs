using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
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
        public IActionResult GetAllUsers()
        {
            var allUsers = _userRepository.GetAllUser();
            return Ok(allUsers);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUserById(int id)
        {
            var userWirhIdDTO = _userRepository.GetUserById(id);
            return Ok(userWirhIdDTO);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update-user-by-id/{id}")]
        public IActionResult UpdateUserById(int id, UserNoIdDTO userDTO)
        {
            var updateUser = _userRepository.UpdateUserById(id, userDTO);
            return Ok(updateUser);

        }
            

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add-user")]
        [Authorize]
        public IActionResult AddUser(UserNoIdDTO userDTO)
        {
            var addUser = _userRepository.AddUser(userDTO);
            return Ok(addUser);
        }

        // DELETE: api/Users/5
        [HttpDelete("delete-user-by-id/{id}")]
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
    }
}
