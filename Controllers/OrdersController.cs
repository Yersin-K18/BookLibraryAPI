using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
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
            var addOrder = _IorderRepository.AddOrder( order);
            return Ok(addOrder);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        
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
    }
}
