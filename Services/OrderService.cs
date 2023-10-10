using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        ApplicationDbContext _db;
        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Order> GetOrder()
        {
            return await _db.Orders.OrderByDescending(x => x.Price).FirstAsync();
        }
        public async Task<List<Order>> GetOrders()
        {
            return await _db.Orders.Where(x => x.Quantity > 10).ToListAsync();
        }
    }
}
