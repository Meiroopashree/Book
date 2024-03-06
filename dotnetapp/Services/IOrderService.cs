using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Services
{
public interface IOrderService
{
    List<Order> GetOrders();
    Order GetOrder(int id);
    void SaveOrder(Order order);
    void UpdateOrder(int id, Order order);
    bool DeleteOrder(int id);
}

}