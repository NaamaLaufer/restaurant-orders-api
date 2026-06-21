using Microsoft.EntityFrameworkCore;
using restaurant_orders_api.Data;
using restaurant_orders_api.Models;

namespace restaurant_orders_api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext _context;

        public OrderRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync() =>
            await _context.Orders
                .Include(o => o.OrderDishes)
                    .ThenInclude(od => od.Dish)
                .ToListAsync();

        public async Task<Order?> GetByIdAsync(int id) =>
            await _context.Orders
                .Include(o => o.OrderDishes)
                    .ThenInclude(od => od.Dish)
                .FirstOrDefaultAsync(o => o.Id == id);

        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order, List<OrderDish> newItems)
        {
            var existing = await _context.Orders
                .Include(o => o.OrderDishes)
                .FirstOrDefaultAsync(o => o.Id == order.Id);

            if (existing == null) return;

            existing.CustomerName = order.CustomerName;
            existing.TotalAmount = order.TotalAmount;

            _context.OrderDishes.RemoveRange(existing.OrderDishes);
            foreach (var item in newItems)
            {
                item.OrderId = existing.Id;
                existing.OrderDishes.Add(item);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}