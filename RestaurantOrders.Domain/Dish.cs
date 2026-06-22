namespace restaurant_orders_api.Models
{
    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public ICollection<OrderDish> OrderDishes { get; set; } = new List<OrderDish>();
    }
}
