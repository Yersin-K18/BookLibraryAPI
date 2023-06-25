using BookLibraryAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly BooklibraryContext _context;

        public SearchController(BooklibraryContext context)
        {
            _context = context;
        }
        [HttpGet("products")]
        public IActionResult GetProductsByAuthor(string author)
        {
            var searchResults = _context.Products
           .Where(p => p.Author.Name.Contains(author) || p.Author.Nickname.Contains(author))
            .ToList();
            if (searchResults.Count == 0) {
                return NotFound("Không tìm thấy sản phẩm ");
            }
            return Ok(searchResults);
        }
    }
}
