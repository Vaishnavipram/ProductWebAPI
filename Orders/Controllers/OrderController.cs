
using Microsoft.AspNetCore.Mvc;
using Orders.Models;
using Orders.Models;
using Orders.Services;



namespace Orders.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;



        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }



        [HttpGet("getAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }



        [HttpGet("getOrderById/{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            if (order == null) return NotFound("Order not found!");
            return Ok(order);
        }



        [HttpGet("getOrdersByCustomerId/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerId(customerId);
            if (orders == null || orders.Count == 0)
                return NotFound("No orders found for this customer!");
            return Ok(orders);
        }



        [HttpPost("addOrder")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            int result = await _orderService.AddOrder(order);
            if (result > 0) return Ok(result);
            return BadRequest();
        }
    }
}

