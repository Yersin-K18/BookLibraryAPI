using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
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
        [HttpGet()]
        public IActionResult GetAllCategory()
        {
            var categories = _categoryRepository.GetAllCategories();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var categoryWithId = _categoryRepository.GetCategoryById(id); 

            return Ok(categoryWithId);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateCategoryById(int id, CategoriesNoIdDTO category)
        {
            var categoryUpdate = _categoryRepository.UpdateCategoryById(id, category);

            return Ok(categoryUpdate);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost()]
        public IActionResult AddCategory(AddCategoriesRequestDTO addCategoryRequestDTO)
        {
            
            try
            {
                if (!ValidateAddCategory(addCategoryRequestDTO))
                {
                    return BadRequest(ModelState);
                }
                if (ModelState.IsValid)
                {
                    var addCategory = _categoryRepository.AddCategory(addCategoryRequestDTO);
                    return Ok(addCategory);
                }
                else return BadRequest(ModelState);
            }
            catch (Exception e) { return BadRequest(e); }
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {
            var CategoryisDeteled = _categoryRepository.GetCategoryById(id);
            return Ok(CategoryisDeteled);
        }

        #region Private methods
        private bool ValidateAddCategory(AddCategoriesRequestDTO category)
        {
            if (category == null)
            {
                ModelState.AddModelError(nameof(category), $"Please add category");


                return false;
            }
            // kiem tra Description NotNull
            if (string.IsNullOrEmpty(category.Name  ))
            {
                ModelState.AddModelError(nameof(category.Name),
                $"{nameof(category.Name)} cannot be null");
            }

            if (string.IsNullOrEmpty(category.Tag))
            {
                ModelState.AddModelError(nameof(category.Tag),
                $"{nameof(category.Tag)} cannot be null");
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
