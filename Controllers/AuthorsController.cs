using BookLibraryAPI.Models;
using BookLibraryAPI.Models.DTO;
using BookLibraryAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly BooklibraryContext _context;
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(BooklibraryContext dbContext, IAuthorRepository
       authorRepository)
        {
            _context = dbContext;
            _authorRepository = authorRepository;
        }
        [HttpGet()]
        public IActionResult GetAllUser()
        {
            var allAuthor = _authorRepository.GetAllAuthor();
            return Ok(allAuthor);
        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var AuthorbyID = _authorRepository.GetAuthorById(id);
            return Ok(AuthorbyID);
        }
        [HttpPost()]
        public IActionResult AddUser([FromBody] AddAuthorDTO
       addAuthorDTO)
        {
            var addAuthor = _authorRepository.AddAuthor(addAuthorDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAuthorById(int id, [FromBody] AuthorNoIdDTO
       authorDTO)
        {
            var authorUpdate = _authorRepository.UpdateAuthor(id, authorDTO);
            return Ok(authorUpdate);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            var userDelete = _authorRepository.DeleteAuthorById(id);
            return Ok();
        }
    }
}
