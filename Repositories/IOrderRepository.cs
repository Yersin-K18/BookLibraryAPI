using BookLibraryAPI.Models.DTO;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Repositories
{
    public interface IOrderRepository
    {
        List<OrderDTO> GetAllOrder();
        OrderDTO GetOrderById(int id);
        AddOrderDTO AddOrder(AddOrderDTO addOrder);
        AddOrderDTO? UpdateOrderById(int id, AddOrderDTO addOrder);
        Order? DeleteOrderById(int id);
    }
}
