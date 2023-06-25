using BookLibraryAPI.Data;
using BookLibraryAPI.Models.Domain;
using BookLibraryAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Repositories
{
    public interface IOrderRepository
    {
        List<OrderDTO> GetAllOrder();
        OrderDTO GetOderById(int id);
        OrderNoIdDTO AddOrder(OrderNoIdDTO addOrderDTO);

        OrderNoIdDTO UpdateOrderById(int id, OrderNoIdDTO OrderDTO);
        Order? DeleteBookById(int id);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly BooklibraryContext _booklibraryContext;
        public OrderRepository(BooklibraryContext booklibraryContext)
        {
            _booklibraryContext = booklibraryContext;
        }
        public OrderNoIdDTO AddOrder(OrderNoIdDTO addOrderRequestDTO)
        {
            
            var orderDoaminModel = new Order
            {
                DateOrder = addOrderRequestDTO.DateOrder,
                Total = addOrderRequestDTO.Total,
                Discount = addOrderRequestDTO.Discount,
                Address = addOrderRequestDTO.Address,
                UserId = addOrderRequestDTO.UserId,
            };
            _booklibraryContext.Orders.Add(orderDoaminModel);
            _booklibraryContext.SaveChanges();          
            return addOrderRequestDTO;
        }

        public Order? DeleteBookById(int id)
        {
            var orderDelete = _booklibraryContext.Orders.FirstOrDefault(o => o.Id == id);
            if(orderDelete != null)
            {
                _booklibraryContext.Orders.Remove(orderDelete);
                _booklibraryContext.SaveChanges();
            }
            return orderDelete;
        }

        public List<OrderDTO> GetAllOrder()
        {
            var allOrders = _booklibraryContext.Orders.Include(c => c.OrderDetails).Select(Orders => new OrderDTO()
            {
                Id = Orders.Id,
                DateOrder = Orders.DateOrder,
                Total = Orders.Total,
                Discount = Orders.Discount,
                Address = Orders.Address,
                UserName = Orders.User.FullName,
                OrderDetailIds = Orders.OrderDetails.Select(o => o.Id).ToList(),
                ProductNames = Orders.OrderDetails.Select(n => n.Product.Name).ToList(),
            }).ToList();
            return allOrders;
        }

        public OrderDTO GetOderById(int id)
        {
            var orderdomain = _booklibraryContext.Orders.Include(c => c.OrderDetails).Where(n => n.Id == id);


            var orderWithIdDTO = orderdomain.Select(order => new OrderDTO()
            {
                Id = order.Id,
                DateOrder = order.DateOrder,
                Total = order.Total,
                Discount = order.Discount,
                Address = order.Address,
                UserName = order.User.FullName,
                OrderDetailIds = order.OrderDetails.Select(n => n.Id).ToList(),
                ProductNames = order.OrderDetails.Select(n => n.Product.Name).ToList()
            }).FirstOrDefault();
            return orderWithIdDTO;
        }

        public OrderNoIdDTO UpdateOrderById(int id, OrderNoIdDTO addOrderRequestDTO)
        {
            var orderDomain = _booklibraryContext.Orders.Include(c=>c.User).FirstOrDefault(n => n.Id==id);
            if(orderDomain != null) {
                orderDomain.DateOrder = addOrderRequestDTO.DateOrder;
                orderDomain.Total = addOrderRequestDTO.Total;
                orderDomain.Discount = addOrderRequestDTO.Discount;
                orderDomain.Address = addOrderRequestDTO.Address;
                orderDomain.UserId = addOrderRequestDTO.UserId;
                _booklibraryContext.SaveChanges();
            }          
            return addOrderRequestDTO;
        }
    }
}
