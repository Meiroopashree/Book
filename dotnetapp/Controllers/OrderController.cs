using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using dotnetapp.Models;

namespace.dotnetapp.Controllers
{

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult GetAllOrders() => Ok(_orderService.GetOrders());

    [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        var order = _orderService.GetOrder(id);
        if (order == null)
            return NotFound();

        return Ok(order);
    }

    [HttpPost]
    public IActionResult AddOrder([FromBody] Order order)
    {
        _orderService.SaveOrder(order);
        return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(int id, [FromBody] Order order)
    {
        _orderService.UpdateOrder(id, order);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        var result = _orderService.DeleteOrder(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}
}
