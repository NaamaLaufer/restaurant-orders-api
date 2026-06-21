using restaurant_orders_api.DTOs;

namespace restaurant_orders_api.Services
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto?> GetByIdAsync(int id);
        Task<(bool Success, OrderDto? Order, string? Error)> CreateAsync(OrderCreateUpdateDto dto);
        Task<(bool Success, string? Error)> UpdateAsync(int id, OrderCreateUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}