namespace Restaurant.Domain.Commands.Plates
{
    public class CreatePlateCommand
    {
        public string PlateName { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }

        public CreatePlateCommand(string plateName, decimal price, int restaurantId)
        {
            PlateName = plateName;
            Price = price;
            RestaurantId = restaurantId;
        }
    }
}
