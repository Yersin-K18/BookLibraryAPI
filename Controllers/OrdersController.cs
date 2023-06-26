using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
using BookLibraryAPI.Models.Domain;
using BookLibraryAPI.Models.DTO;
using BookLibraryAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly BooklibraryContext _context;
        private readonly IOrderRepository _IorderRepository;
        public OrdersController(BooklibraryContext context, IOrderRepository orderRepository)
        {
            _context = context;
            _IorderRepository = orderRepository;
        }

        // GET: api/Orders
        [HttpGet]
        
        public IActionResult GetOrders()
        {
            var allOrders = _IorderRepository.GetAllOrder();
            return Ok(allOrders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        
        public IActionResult GetOrder(int id)
        {
            var Order = _IorderRepository.GetOderById(id);
            return Ok(Order);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        
        public IActionResult PutOrder( int id, OrderNoIdDTO order)
        {
            
            var updateOrder = _IorderRepository.UpdateOrderById(id, order);
            return Ok(updateOrder);

        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        
        public IActionResult PostOrder(OrderNoIdDTO order)
        {
            
            try
            {
                if (!ValidateAddOrder(order))
                {
                    return BadRequest(ModelState);
                }
                if (ModelState.IsValid)
                {
                    var addOrder = _IorderRepository.AddOrder(order);
                    return Ok(addOrder);
                }
                else return BadRequest(ModelState);
            }
            catch (Exception e) { return BadRequest(e); }
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        [Authorize]


        public IActionResult DeleteOrder(int id)
        {
            var deletedOrder = _IorderRepository.DeleteBookById(id);
            return Ok(deletedOrder);
        }
        [HttpGet("GetOrdersByUserId/{userId}")]
        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #region Private methods
        private bool ValidateAddOrder(OrderNoIdDTO order)
        {
            if (order == null)
            {
                ModelState.AddModelError(nameof(order), $"Please add book data");


                return false;
            }
            // kiem tra Description NotNull
            if (string.IsNullOrEmpty(order.Address))
            {
                ModelState.AddModelError(nameof(order.Address),
                $"{nameof(order.Address)} cannot be null");
            }
            if (order.Discount == 0)
            {
                ModelState.AddModelError(nameof(order.Discount), $"{nameof(order.Discount)} cannot be null or zero");
            }
            if (order.UserId == 0)
            {
                ModelState.AddModelError(nameof(order.UserId), $"{nameof(order.UserId)} cannot be null or zero");
            }
            if (order.Total == 0)
            {
                ModelState.AddModelError(nameof(order.Total),
                $"{nameof(order.Total)} cannot be null");
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
