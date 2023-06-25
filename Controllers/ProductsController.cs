using BookLibraryAPI.Data;
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
    public class ProductsController : ControllerBase
    {
        private readonly BooklibraryContext _context;

        private readonly IProductRepository _productRepository;
        public ProductsController(BooklibraryContext dbContext, IProductRepository productRepository)
        {
            _context = dbContext;
            _productRepository = productRepository;
        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            // su dung reposity pattern 
            var allproducts = _productRepository.GetAllProduct();
            return Ok(allproducts);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBookById([FromRoute] int id)
        {
            var productWithDTO = _productRepository.GetProductById(id);
            return Ok(productWithDTO);
        }
        [HttpPost()]
        public IActionResult AddBook([FromBody] AddProductDTO addproductRequestDTO)
        {
            var productAdd = _productRepository.AddProduct(addproductRequestDTO);
            return Ok(productAdd);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] AddProductDTO productDTO)
        {
            var updateProduct = _productRepository.UpdateProductById(id, productDTO);
            return Ok(productDTO);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(int id)
        {
            var deleteProduct = _productRepository.DeleteProductById(id);
            return Ok(deleteProduct);
        }
        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("BestSellingProducts/{number}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetBestSellingProducts(int number)
        {
            if (number < 0) return NotFound();
            if (_context.Products == null)
            {
                return NotFound();
            }
            return await _context.Products
                .OrderBy(item => item.Quantity)
                .Take(number)
                .ToListAsync();
        }
    }
}
