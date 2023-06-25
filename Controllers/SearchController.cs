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
        [HttpGet("searchProduct")]
        public IActionResult searchPruduct(string keyword)
        {
            var searchResults = _context.Products
            .Where(a => !(!a.Name.Contains(keyword)))
            .ToList();
            if ( searchResults.Count == 0)
            {
                return NotFound("không tìm thấy sản phẩm");
            }    
            return Ok(searchResults);
        }
        [HttpGet("productbycategory")]
        public IActionResult GetProductsByCategory(string category)
        {
            var searchResults = _context.Products
           .Where(p => p.Categorie.Name.Contains(category) || p.Categorie.Tag.Contains(category))
            .ToList();
            if (searchResults.Count == 0)
            {
                return NotFound("Không tìm thấy sản phẩm ");
            }
            return Ok(searchResults);
        }
    }
}
