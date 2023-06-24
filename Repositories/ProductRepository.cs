using BookLibraryAPI.Models.DTO;
using BookLibraryAPI.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
            private readonly BooklibraryContext _context;
            public ProductRepository(BooklibraryContext dbContext)
            {
                _context = dbContext;
            }
            public AddProductDTO AddProduct(AddProductDTO addProductDTO)
            {
                var productmodels = new Product
                {
                    Name = addProductDTO.Name,
                    Description = addProductDTO.Description,
                    Price = addProductDTO.Price,
                    Language = addProductDTO.Language,
                    Image = addProductDTO.Image,
                    Quantity = addProductDTO.Quantity,
                    AuthorId = addProductDTO.AuthorId,
                    CategorieId = addProductDTO.CategorieId,
                };
                //Use Domain Model to add Book
                _context.Products.Add(productmodels);
                _context.SaveChanges();
                return addProductDTO;
            }

            public Product? DeleteProductById(int id)
            {
                var bookDomain = _context.Products.FirstOrDefault(n => n.Id == id);
                if (bookDomain != null)
                {
                    _context.Products.Remove(bookDomain);
                    _context.SaveChanges();
                }
                return bookDomain;

            }

            public List<ProductDTO> GetAllProduct()
            {
                var AllProduct = _context.Products.Select(product => new ProductDTO()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Language = product.Language,
                    Image = product.Image,
                    Quantity = product.Quantity,
                    AuthorName = product.Author.Name,
                    CategoriesName = product.Categorie.Name,
                }).ToList();
                return AllProduct;
            }

            public ProductDTO GetProductById(int id)
            {
                var productwithModels = _context.Products.Where(n => n.Id == id);
                //Map Domain Model to DTOs
                var productwithDTO = productwithModels.Select(product => new
               ProductDTO()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Language = product.Language,
                    Image = product.Image,
                    Quantity = product.Quantity,
                    AuthorName = product.Author.Name,
                    CategoriesName = product.Categorie.Name,
                }).FirstOrDefault();
                return productwithDTO;

            }

            public AddProductDTO? UpdateProductById(int id, AddProductDTO productDTO)
            {
                var ProductModels = _context.Products.FirstOrDefault(n => n.Id == id);
                if (ProductModels != null)
                {
                    ProductModels.Name = productDTO.Name;
                    ProductModels.Description = productDTO.Description;
                    ProductModels.Price = productDTO.Price;
                    ProductModels.Language = productDTO.Language;
                    ProductModels.Image = productDTO.Image;
                    ProductModels.Quantity = productDTO.Quantity;
                    ProductModels.AuthorId = productDTO.AuthorId;
                    ProductModels.CategorieId = productDTO.CategorieId;
                    _context.SaveChanges();

                };
                return productDTO;

            }
        }
    }
