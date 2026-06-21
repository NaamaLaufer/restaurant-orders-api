using Microsoft.AspNetCore.Mvc;
using restaurant_orders_api.DTOs;
using restaurant_orders_api.Services;

namespace restaurant_orders_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            return Ok(await _orderService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create(OrderCreateUpdateDto dto)
        {
            var (success, order, error) = await _orderService.CreateAsync(dto);
            if (!success) return BadRequest(error);
            return CreatedAtAction(nameof(GetById), new { id = order!.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderCreateUpdateDto dto)
        {
            var (success, error) = await _orderService.UpdateAsync(id, dto);
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
            var deleted = await _orderService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
