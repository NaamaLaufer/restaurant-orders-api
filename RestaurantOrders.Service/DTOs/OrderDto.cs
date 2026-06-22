namespace restaurant_orders_api.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public List<OrderItemDto> Items { get; set; } = new();
    }
}
