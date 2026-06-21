namespace restaurant_orders_api.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Dish> Dishes { get; set; }
	}
}