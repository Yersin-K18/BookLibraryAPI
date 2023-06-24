using BookLibraryAPI.Models.DTO;
using BookLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc;
using static NuGet.Packaging.PackagingConstants;
using System.Net;

namespace BookLibraryAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BooklibraryContext _context;
        public OrderRepository(BooklibraryContext context)
        {
            _context = context;
        }
        public AddOrderDTO AddOrder(AddOrderDTO addOrder)
        {
            var OrderModels = new Order
            {
                DateOrder = addOrder.DateOrder,
                Total = addOrder.Total,
                Discount= addOrder.Discount,
                UserId= addOrder.UserId,
                Address= addOrder.Address,

            };
            //Use Domain Model to add Book
            _context.Orders.Add(OrderModels);
            _context.SaveChanges();
            foreach (var id in addOrder.ProductId)
            {
                var _order_detals = new OrderDetail()
                {
                    OrderId = OrderModels.Id,
                    ProductId = id,
                };
                _context.OrderDetails.Add(_order_detals);
                _context.SaveChanges();
            }
            return addOrder;
        }

        public Order? DeleteOrderById(int id)
        {
            {
                var OrderModels = _context.Orders.FirstOrDefault(n => n.Id == id);
                if (OrderModels != null)
                {
                    _context.Orders.Remove(OrderModels);
                    _context.SaveChanges();
                }
                return OrderModels;
            }
        }

        public List<OrderDTO> GetAllOrder()
        {
            var allOrder = _context.Orders.Select(Orders => new OrderDTO()
            {
                DateOrder = Orders.DateOrder,
                Total = Orders.Total,
                Discount = Orders.Discount,
                UserFullName = Orders.User.FullName,
                Address = Orders.Address,
                ProductNames = Orders.OrderDetails.Select(n => n.Product.Name).ToList()
            }).ToList();
            return allOrder;
        }

        public OrderDTO GetOrderById(int id)
        {
            var OrderWithModel = _context.Orders.Where(n => n.Id == id);
            //Map Domain Model to DTOs
            var OrderWithIdDTO = OrderWithModel.Select(Order => new
           OrderDTO()
            {
                Id= Order.Id,
                DateOrder = Order.DateOrder,
                Total = Order.Total,
                Discount = Order.Discount,
                UserFullName = Order.User.FullName,
                Address = Order.Address,
                ProductNames = Order.OrderDetails.Select(n => n.Product.Name).ToList()
            }).FirstOrDefault();
            return OrderWithIdDTO;
        }

        public AddOrderDTO? UpdateOrderById(int id, AddOrderDTO addOrder)
        {
            var OrderModels = _context.Orders.FirstOrDefault(n => n.Id == id);
            if (OrderModels != null)
            {
                OrderModels.DateOrder = addOrder.DateOrder;
                OrderModels.Total = addOrder.Total;
                OrderModels.Discount = addOrder.Discount;
                OrderModels.UserId = addOrder.UserId;
                OrderModels.Address = addOrder.Address;
                _context.SaveChanges();
            }
            var ProuducModels = _context.OrderDetails.Where(a => a.ProductId == id).ToList();
            if (ProuducModels != null)
            {
                _context.OrderDetails.RemoveRange(ProuducModels);
                _context.SaveChanges();
            }
            foreach (var productid in addOrder.ProductId)
            {
                var _Order_details = new OrderDetail()
                {
                    OrderId = id,
                    ProductId = productid
                };
                _context.OrderDetails.Add(_Order_details);
                _context.SaveChanges();
            }
            return addOrder;

        }
    }

}
