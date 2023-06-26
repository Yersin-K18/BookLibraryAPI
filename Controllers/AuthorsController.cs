using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
using BookLibraryAPI.Models.Domain;
using BookLibraryAPI.Models.DTO;
using BookLibraryAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BooklibraryContext _context;
        private readonly IAuthorRepository _authorRepository;
        public AuthorsController(BooklibraryContext context, IAuthorRepository authorRepository)
        {
            _context = context;
            _authorRepository = authorRepository;
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            return Ok(authors);
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            var authorWithId = _authorRepository.GetAuthorById(id);

            return Ok(authorWithId);
            
        }

        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, AddAuthorRequestDTO author)
        {
            var authorUpdate = _authorRepository.UpdateAuthorById(id, author);

            return Ok(authorUpdate);
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        
        public IActionResult PostAuthor(AddAuthorRequestDTO author)
        {
            try
            {
                if (!ValidateAddAuthor(author))
                {
                    return BadRequest(ModelState);
                }
                if (ModelState.IsValid)
                {
                    var addAuthor = _authorRepository.AddAuthor(author);
                    return Ok(addAuthor);
                }
                else return BadRequest(ModelState);
            }
            catch (Exception e) { return BadRequest(e); }  
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteAuthor(int id)
        {
            var AuthorById = _authorRepository.DeleteAuthorById(id);
            return Ok(AuthorById);
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #region Private methods
        private bool ValidateAddAuthor(AddAuthorRequestDTO author)
        {
            if (author == null)
            {
                ModelState.AddModelError(nameof(author), $"Please add book data");


            return false;
            }
            // kiem tra Description NotNull
            if (string.IsNullOrEmpty(author.Description))
            {
                ModelState.AddModelError(nameof(author.Description),
                $"{nameof(author.Description)} cannot be null");
            }
           
            if (string.IsNullOrEmpty(author.Name))
            {
                ModelState.AddModelError(nameof(author.Name),
                $"{nameof(author.Name)} cannot be null");
            }
            if (string.IsNullOrEmpty(author.Nickname))
            {
                ModelState.AddModelError(nameof(author.Nickname),
                $"{nameof(author.Nickname)} cannot be null");
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
