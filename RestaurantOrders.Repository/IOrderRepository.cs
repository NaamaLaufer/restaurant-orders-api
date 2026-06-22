using restaurant_orders_api.Models;

namespace restaurant_orders_api.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task AddAsync(Order order);

        Task UpdateAsync(Order order, List<OrderDish> newItems);
        Task DeleteAsync(Order order);
    }
}
