using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
using BookLibraryAPI.Models.DTO;

namespace BookLibraryAPI.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetailDTO> GetById(int id);
        void Add(OrderDetailNoIdDTO orderDetail);
        void Update(OrderDetailNoIdDTO orderDetail);
        void Delete(int id);
    }

    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly BooklibraryContext _booklibraryContext;

        public OrderDetailRepository(BooklibraryContext _booklibraryContext)
        {
            this._booklibraryContext = _booklibraryContext;
        }

        public async Task<OrderDetailDTO?> GetById(int id)
        {
            var result = _booklibraryContext.OrderDetails
                .FirstOrDefault(n => n.Id == id);
            if (result == null)
            {
                return null;
            }
            var data = new OrderDetailDTO()
            {
                Id = id,
                OrderId = result.OrderId,
                ProductId = result.ProductId,
                UnitPrice = result.UnitPrice,
                Quantity = result.Quantity
            };
            return data;
        }

        public void Add(OrderDetailNoIdDTO orderDetail)
        {
            var data = new OrderDetail
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                UnitPrice = orderDetail.UnitPrice,
                Quantity = orderDetail.Quantity
            };

            _booklibraryContext.OrderDetails.Add(data);
            _booklibraryContext.SaveChanges();
            return;
        }

        public void Update(OrderDetailNoIdDTO orderDetail)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
