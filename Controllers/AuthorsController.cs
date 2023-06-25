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
            var addAuthor = _authorRepository.AddAuthor(author);
            return Ok(addAuthor);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var AuthorById = _authorRepository.DeleteAuthorById(id);
            return Ok(AuthorById);
        }

        private bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
