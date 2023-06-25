using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
using BookLibraryAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Repositories
{
    public class SQLCategoryRepository : ICategoryRepository

    {
        private readonly BooklibraryContext _booklibraryContext;
        public SQLCategoryRepository(BooklibraryContext booklibraryContext)
        {
            _booklibraryContext = booklibraryContext;
        }
        public AddCategoriesRequestDTO AddCategory(AddCategoriesRequestDTO addCategoryRequestDTO)
        {
            var categoryModel = new Category
            {
                Name = addCategoryRequestDTO.Name,
                Tag = addCategoryRequestDTO.Tag,
            };

            _booklibraryContext.Categories.Add(categoryModel);
            _booklibraryContext.SaveChanges();
            return addCategoryRequestDTO;
        }

        public Category DeleteCategoryById(int id)
        {
            var CategoryDomain = _booklibraryContext.Categories.FirstOrDefault(c => c.Id == id);
            if (CategoryDomain != null)
            {
                _booklibraryContext.Categories.Remove(CategoryDomain);
                _booklibraryContext.SaveChanges();
            }
            return null;
        }

        public List<CategoriesDTO> GetAllCategories()
        {
            var allCategoriesDomain = _booklibraryContext.Categories.Include(c => c.Products).Select(Category => new CategoriesDTO()
            {
                Id = Category.Id,
                Name = Category.Name,
                Tag = Category.Tag,
                ProductNames = Category.Products.Select(n => n.Name).ToList()
            }).ToList();
            return allCategoriesDomain;
        }

        public CategoriesDTO GetCategoryById(int id)
        {
            var categoryWithDomain = _booklibraryContext.Categories
            .FirstOrDefault(n => n.Id == id);

            var categoryIdDTO = new CategoriesDTO()
            {
                Id = categoryWithDomain.Id,
                Name = categoryWithDomain.Name,
                Tag = categoryWithDomain.Tag,
                ProductNames = categoryWithDomain.Products.Select(n => n.Name).ToList(),
            };
            return categoryIdDTO;
        }

        public CategoriesNoIdDTO UpdateCategoryById(int id, CategoriesNoIdDTO categoryDTO)
        {
            var categoryDomain = _booklibraryContext.Categories.FirstOrDefault(c => c.Id == id);

            if (categoryDomain != null)
            {
                categoryDomain.Name = categoryDTO.Name;
                categoryDomain.Tag = categoryDTO.Tag;
                _booklibraryContext.SaveChanges();
            }
            return categoryDTO;
        }
    }
}
