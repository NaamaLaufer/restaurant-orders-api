using restaurant_orders_api.DTOs;

namespace restaurant_orders_api.Services
{
    public interface IDishService
    {
        Task<List<DishDto>> GetAllAsync();
        Task<DishDto?> GetByIdAsync(int id);
        Task<(bool Success, DishDto? Dish, string? Error)> CreateAsync(DishCreateUpdateDto dto);
        Task<(bool Success, string? Error)> UpdateAsync(int id, DishCreateUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}