using System.ComponentModel.DataAnnotations;

namespace restaurant_orders_api.DTOs
{
    public class OrderItemCreateDto
    {
        [Required]
        public int DishId { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}
