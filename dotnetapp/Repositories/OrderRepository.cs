using System.Collections.Generic;

namespace dotnetapp.Repositories
{
public class OrderRepository
{
    private List<Order> orders = new List<Order>();

    public List<Order> GetOrders() => orders;

    public Order GetOrder(int id) => orders.Find(o => o.OrderId == id);

    public void SaveOrder(Order order) => orders.Add(order);

    public void UpdateOrder(int id, Order order)
    {
        var existingOrder = orders.Find(o => o.OrderId == id);
        if (existingOrder != null)
        {
            existingOrder.CustomerName = order.CustomerName;
            existingOrder.TotalAmount = order.TotalAmount;
        }
    }

    public void DeleteOrder(int id) => orders.RemoveAll(o => o.OrderId == id);
}
}
