using AutoMapper;
using restaurant_orders_api.DTOs;
using restaurant_orders_api.Models;
using restaurant_orders_api.Repositories;

namespace restaurant_orders_api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IDishRepository dishRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _dishRepository = dishRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return order == null ? null : _mapper.Map<OrderDto>(order);
        }

        public async Task<(bool Success, OrderDto? Order, string? Error)> CreateAsync(OrderCreateUpdateDto dto)
        {
            var (items, error) = await BuildOrderItemsAsync(dto.Items);
            if (error != null) return (false, null, error);

            var order = new Order
            {
                CustomerName = dto.CustomerName,
                OrderDate = DateTime.UtcNow,
                TotalAmount = items.Sum(i => i.Dish.Price * i.Quantity),
                OrderDishes = items
            };

            await _orderRepository.AddAsync(order);

            var created = await _orderRepository.GetByIdAsync(order.Id);
            return (true, _mapper.Map<OrderDto>(created), null);
        }

        public async Task<(bool Success, string? Error)> UpdateAsync(int id, OrderCreateUpdateDto dto)
        {
            var existing = await _orderRepository.GetByIdAsync(id);
            if (existing == null) return (false, "not_found");

            var (items, error) = await BuildOrderItemsAsync(dto.Items);
            if (error != null) return (false, error);

            existing.CustomerName = dto.CustomerName;
            existing.TotalAmount = items.Sum(i => i.Dish.Price * i.Quantity);

            await _orderRepository.UpdateAsync(existing, items);
            return (true, null);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _orderRepository.GetByIdAsync(id);
            if (existing == null) return false;

            await _orderRepository.DeleteAsync(existing);
            return true;
        }

        private async Task<(List<OrderDish> Items, string? Error)> BuildOrderItemsAsync(List<OrderItemCreateDto> itemDtos)
        {
            var items = new List<OrderDish>();

            foreach (var itemDto in itemDtos)
            {
                var dish = await _dishRepository.GetByIdAsync(itemDto.DishId);
                if (dish == null)
                    return (items, $"Dish with id {itemDto.DishId} does not exist.");

                items.Add(new OrderDish
                {
                    DishId = dish.Id,
                    Dish = dish,
                    Quantity = itemDto.Quantity
                });
            }

            return (items, null);
        }
    }
}
