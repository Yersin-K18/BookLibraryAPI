using BookLibraryAPI.Data;
using Microsoft.AspNetCore.Authorization;
using BookLibraryAPI.Models.DTO;
using BookLibraryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibraryAPI.Models.Domain;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly BooklibraryContext _context;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailsController(BooklibraryContext context, IOrderDetailRepository orderDetailRepository)
        {
            _context = context;
            _orderDetailRepository = orderDetailRepository;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
        {
            if (_context.OrderDetails == null)
            {
                return NotFound();
            }
            return await _context.OrderDetails.ToListAsync();
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailDTO>> GetOrderDetail(int id)
        {
            if (_context.OrderDetails == null)
            {
                return NotFound();
            }
            var orderDetail = await _orderDetailRepository.GetById(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return orderDetail;
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(int id, OrderDetailNoIdDTO orderDetail)
        {
            try
            {
                _orderDetailRepository.Update(id, orderDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(orderDetail);
        }

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostOrderDetail(OrderDetailNoIdDTO orderDetail)
        {
            if (_context.OrderDetails == null)
            {
                return Problem("Entity set 'BooklibraryContext.OrderDetails'  is null.");
            }
            try
            {
                _orderDetailRepository.Add(orderDetail);
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return Ok(orderDetail);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            if (_context.OrderDetails == null)
            {
                return NotFound();
            }
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _orderDetailRepository.Delete(orderDetail);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool OrderDetailExists(int id)
        {
            return (_context.OrderDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
