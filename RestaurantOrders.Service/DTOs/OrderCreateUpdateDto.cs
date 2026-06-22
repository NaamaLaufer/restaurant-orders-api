using System.ComponentModel.DataAnnotations;

namespace restaurant_orders_api.DTOs
{
    public class OrderCreateUpdateDto
    {
        [Required, StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required, MinLength(1)]
        public List<OrderItemCreateDto> Items { get; set; } = new();
    }
}
