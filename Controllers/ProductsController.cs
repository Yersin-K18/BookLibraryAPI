using BookLibraryAPI.Data;
using BookLibraryAPI.Models.Domain;
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
        public IActionResult AddBook([FromBody] AddProductRequestDTO addproductRequestDTO)
        {
            try
            {
                if (!ValidateAddProduct(addproductRequestDTO))
                {
                    return BadRequest(ModelState);
                }
                if (ModelState.IsValid)
                {
                    var productAdd = _productRepository.AddProduct(addproductRequestDTO);
                    return Ok(productAdd);
                }
                else return BadRequest(ModelState);
            }
            catch (Exception e) { return BadRequest(e); }
            
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] AddProductRequestDTO productDTO)
        {
            var updateProduct = _productRepository.UpdateProductById(id, productDTO);
            return Ok(productDTO);
        }
        [HttpDelete("{id}")]
        [Authorize]

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
        #region Private methods
        private bool ValidateAddProduct(AddProductRequestDTO product)
        {
            if (product == null)
            {
                ModelState.AddModelError(nameof(product), $"Please add book data");


                return false;
            }
            // kiem tra Description NotNull
            if (string.IsNullOrEmpty(product.Description))
            {
                ModelState.AddModelError(nameof(product.Description),
                $"{nameof(product.Description)} cannot be null");
            }

            if (string.IsNullOrEmpty(product.Name))
            {
                ModelState.AddModelError(nameof(product.Name),
                $"{nameof(product.Name)} cannot be null");
            }
            if (string.IsNullOrEmpty(product.Image))
            {
                ModelState.AddModelError(nameof(product.Image),
                $"{nameof(product.Image)} cannot be null");
            }
            if (product.Price == 0)
            {
                ModelState.AddModelError(nameof(product.Price),
                $"{nameof(product.Price)} cannot be null");
            }
            if (product.Quantity == 0)
            {
                ModelState.AddModelError(nameof(product.Quantity),
                $"{nameof(product.Quantity)} cannot be null");
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
