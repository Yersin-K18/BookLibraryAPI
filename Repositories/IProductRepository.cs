using BookLibraryAPI.Models.DTO;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Repositories
{
    public interface IProductRepository
    {
        List<ProductDTO> GetAllProduct();
        ProductDTO GetProductById(int id);
        AddProductDTO AddProduct(AddProductDTO addProductDTO);
        AddProductDTO? UpdateProductById(int id, AddProductDTO productDTO);
        Product? DeleteProductById(int id);
    }
}
