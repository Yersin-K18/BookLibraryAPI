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
    public class CategoriesController : ControllerBase
    {
        private readonly BooklibraryContext _context;
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(BooklibraryContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
        }

        // GET: api/Categories
        [HttpGet("get-all-category")]
        public IActionResult GetAllCategory()
        {
            var categories = _categoryRepository.GetAllCategories();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("category-by-id/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var categoryWithId = _categoryRepository.GetCategoryById(id); 

            return Ok(categoryWithId);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update-category-by/{id}")]
        public IActionResult UpdateCategoryById(int id, CategoriesNoIdDTO category)
        {
            var categoryUpdate = _categoryRepository.UpdateCategoryById(id, category);

            return Ok(categoryUpdate);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add-category")]
        public IActionResult AddCategory(AddCategoriesRequestDTO addCategoryRequestDTO)
        {
            var addCategory = _categoryRepository.AddCategory(addCategoryRequestDTO);
            return Ok(addCategory);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {
            var CategoryisDeteled = _categoryRepository.GetCategoryById(id);
            return Ok(CategoryisDeteled);
        }

        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
