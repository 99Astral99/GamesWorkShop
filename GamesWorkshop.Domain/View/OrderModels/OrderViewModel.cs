namespace GamesWorkshop.Domain.View.OrderModels
{
	public class OrderViewModel
	{
		public int Id { get; set; }
		public string ProductName { get; set; }
		public double Price { get; set; }
		public int Count { get; set; }
		public string ImageSrc { get; set; }
	}
}
