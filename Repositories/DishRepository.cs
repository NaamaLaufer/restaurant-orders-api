using Microsoft.EntityFrameworkCore;
using restaurant_orders_api.Data;
using restaurant_orders_api.Models;

namespace restaurant_orders_api.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly RestaurantDbContext _context;

        public DishRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Dish>> GetAllAsync() =>
            await _context.Dishes.Include(d => d.Category).ToListAsync();

        public async Task<Dish?> GetByIdAsync(int id) =>
            await _context.Dishes.Include(d => d.Category).FirstOrDefaultAsync(d => d.Id == id);

        public async Task<bool> CategoryExistsAsync(int categoryId) =>
            await _context.Categories.AnyAsync(c => c.Id == categoryId);

        public async Task AddAsync(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Dish dish)
        {
            _context.Dishes.Update(dish);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Dish dish)
        {
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
        }
    }
}