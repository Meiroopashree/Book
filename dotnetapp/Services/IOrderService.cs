using System.Collections.Generic;

namespace.dotnetapp.Services
{
public interface IOrderService
{
    List<Order> GetOrders();
    Order GetOrder(int id);
    void SaveOrder(Order order);
    void UpdateOrder(int id, Order order);
    void DeleteOrder(int id);
}
}