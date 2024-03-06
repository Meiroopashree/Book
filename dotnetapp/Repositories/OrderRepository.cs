using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Repositories
{
    public class OrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> GetOrders() => _context.Orders.ToList();

        public Order GetOrder(int id) => _context.Orders.FirstOrDefault(o => o.OrderId == id);

        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(int id, Order order)
        {
            var existingOrder = _context.Orders.Find(id);
            if (existingOrder != null)
            {
                existingOrder.CustomerName = order.CustomerName;
                existingOrder.TotalAmount = order.TotalAmount;
                _context.SaveChanges();
            }
        }

        public bool DeleteOrder(int id)
        {
            var orderToRemove = _context.Orders.Find(id);
            if (orderToRemove != null)
            {
                _context.Orders.Remove(orderToRemove);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
