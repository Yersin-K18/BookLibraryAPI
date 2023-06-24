using BookLibraryAPI.Models;
using BookLibraryAPI.Models.DTO;

namespace BookLibraryAPI.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoriesDTO> GetAllCategories();
        CategoriesDTO GetCategoryById(int id);
        AddCategoriesRequestDTO AddCategory(AddCategoriesRequestDTO addCategoryRequestDTO);
        CategoriesNoIdDTO UpdateCategoryById(int id, CategoriesNoIdDTO categoryDTO);
        Category DeleteCategoryById(int id);
    }
}
