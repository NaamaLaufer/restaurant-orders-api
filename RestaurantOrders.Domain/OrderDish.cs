namespace restaurant_orders_api.Models
{
    public class OrderDish
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int DishId { get; set; }
        public Dish Dish { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
