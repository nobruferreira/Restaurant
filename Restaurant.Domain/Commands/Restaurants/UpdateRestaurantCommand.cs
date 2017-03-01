namespace Restaurant.Domain.Commands.Restaurants
{
    public class UpdateRestaurantCommand
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }

        public UpdateRestaurantCommand(int restaurantId, string restaurantName)
        {
            RestaurantId = restaurantId;
            RestaurantName = restaurantName;
        }
    }
}
