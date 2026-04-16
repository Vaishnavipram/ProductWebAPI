using Orders.Models;
//using OrdersAPI.Models;



namespace Orders.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders();
        Task<Order?> GetOrderById(int orderId);
        Task<List<Order>> GetOrdersByCustomerId(int customerId);
        Task<int> AddOrder(Order order);
    }
} //iorder