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
    public class OrdersController : ControllerBase
    {
        private readonly BooklibraryContext _context;
        private readonly IOrderRepository _orderRepository;

        public OrdersController(BooklibraryContext context,IOrderRepository orderRepository)
        {
            _context = context;
            _orderRepository = orderRepository;
        }

        // GET: api/Orders
        [HttpGet("get-all-Orders")]
        public IActionResult GetAll()
        {
            // su dung reposity pattern 
            var allOrders = _orderRepository.GetAllOrder();
            return Ok(allOrders);
        }
        [HttpGet]
        [Route("get-Order-by-id/{id}")]
        public IActionResult GetOrderById([FromRoute] int id)
        {
            var OrderWithIdDTO = _orderRepository.GetOrderById(id);
            return Ok(OrderWithIdDTO);
        }
        [HttpPost("add Order")]
        public IActionResult AddOrder([FromBody] AddOrderDTO addOrderDTO)
        {
            var OrderAdd = _orderRepository.AddOrder(addOrderDTO);
            return Ok(OrderAdd);
        }
        [HttpPut("update-order-by-id/{id}")]
        public IActionResult UpdateOrderById(int id, [FromBody] AddOrderDTO addOrderDTO)
        {
            var updateOrder = _orderRepository.AddOrder(addOrderDTO);
            return Ok(updateOrder);
        }
        [HttpDelete("delete-Order-by-id/{id}")]
        public IActionResult DeleteOrderById(int id)
        {
            var deleteOrder = _orderRepository.DeleteOrderById(id);
            return Ok(deleteOrder);
        }
        [HttpGet("GetOrdersByUserId/{userId}")]
        public ActionResult<IEnumerable<Order>> GetOrdersByUserId(int userId)
        {
            List<Order> orders = _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.UserId == userId)
                .ToList();

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }
        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
