using Microsoft.AspNetCore.Mvc;
using restaurant_orders_api.DTOs;
using restaurant_orders_api.Services;

namespace restaurant_orders_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishesController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishesController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DishDto>>> GetAll()
        {
            return Ok(await _dishService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishDto>> GetById(int id)
        {
            var dish = await _dishService.GetByIdAsync(id);
            if (dish == null) return NotFound();
            return Ok(dish);
        }

        [HttpPost]
        public async Task<ActionResult<DishDto>> Create(DishCreateUpdateDto dto)
        {
            var (success, dish, error) = await _dishService.CreateAsync(dto);
            if (!success) return BadRequest(error);

            return CreatedAtAction(nameof(GetById), new { id = dish!.Id }, dish);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DishCreateUpdateDto dto)
        {
            var (success, error) = await _dishService.UpdateAsync(id, dto);
            if (!success)
            {
                if (error == "not_found") return NotFound();
                return BadRequest(error);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _dishService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
