using System.ComponentModel.DataAnnotations;

namespace restaurant_orders_api.DTOs
{
    public class DishCreateUpdateDto
    {
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}