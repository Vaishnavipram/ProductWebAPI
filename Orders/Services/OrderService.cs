using Microsoft.EntityFrameworkCore;
using Orders.Data;
using Orders.Models;
using Orders.Services;
//using OrdersAPI.Data;
//using OrdersAPI.Models;



namespace Orders.Services
{
    public class OrderService : IOrderService
    {
        public readonly OrderContext _context;



        public OrderService(OrderContext context)
        {
            _context = context;
        }



        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Staff)
            .Include(o => o.Store)
            .Include(o => o.OrderItems)
            .ToListAsync();
        }



        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Staff)
            .Include(o => o.Store)
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }



        public async Task<List<Order>> GetOrdersByCustomerId(int customerId)
        {
            return await _context.Orders
            .Include(o => o.OrderItems)
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();
        }



        public async Task<int> AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.OrderId;
        }
    }
}