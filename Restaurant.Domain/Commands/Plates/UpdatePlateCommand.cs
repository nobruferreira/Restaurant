namespace Restaurant.Domain.Commands.Plates
{
    public class UpdatePlateCommand
    {
        public int PlateId { get; set; }
        public string PlateName { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }

        public UpdatePlateCommand(int plateId, string plateName, decimal price, int restaurantId)
        {
            PlateId = plateId;
            Price = price;
            PlateName = plateName;
            RestaurantId = restaurantId;
        }
    }
}
