namespace restaurant_orders_api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<OrderDish> OrderDishes { get; set; }
    }
}