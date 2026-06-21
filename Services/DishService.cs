using AutoMapper;
using restaurant_orders_api.DTOs;
using restaurant_orders_api.Repositories;

namespace restaurant_orders_api.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _repository;
        private readonly IMapper _mapper;

        public DishService(IDishRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DishDto>> GetAllAsync()
        {
            var dishes = await _repository.GetAllAsync();
            return _mapper.Map<List<DishDto>>(dishes);
        }

        public async Task<DishDto?> GetByIdAsync(int id)
        {
            var dish = await _repository.GetByIdAsync(id);
            return dish == null ? null : _mapper.Map<DishDto>(dish);
        }

        public async Task<(bool Success, DishDto? Dish, string? Error)> CreateAsync(DishCreateUpdateDto dto)
        {
            if (!await _repository.CategoryExistsAsync(dto.CategoryId))
                return (false, null, $"Category with id {dto.CategoryId} does not exist.");

            var dish = _mapper.Map<restaurant_orders_api.Models.Dish>(dto);
            await _repository.AddAsync(dish);

            var created = await _repository.GetByIdAsync(dish.Id);
            return (true, _mapper.Map<DishDto>(created), null);
        }

        public async Task<(bool Success, string? Error)> UpdateAsync(int id, DishCreateUpdateDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return (false, "not_found");

            if (!await _repository.CategoryExistsAsync(dto.CategoryId))
                return (false, $"Category with id {dto.CategoryId} does not exist.");

            existing.Name = dto.Name;
            existing.Price = dto.Price;
            existing.CategoryId = dto.CategoryId;

            await _repository.UpdateAsync(existing);
            return (true, null);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(existing);
            return true;
        }
    }
}