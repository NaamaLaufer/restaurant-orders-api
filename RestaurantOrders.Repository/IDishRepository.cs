using restaurant_orders_api.Models;

namespace restaurant_orders_api.Repositories
{
    public interface IDishRepository
    {
        Task<List<Dish>> GetAllAsync();
        Task<Dish?> GetByIdAsync(int id);
        Task<bool> CategoryExistsAsync(int categoryId);
        Task AddAsync(Dish dish);
        Task UpdateAsync(Dish dish);
        Task DeleteAsync(Dish dish);
    }
}
