namespace Restaurant.Domain.Commands.Restaurants
{
    public class CreateRestaurantCommand
    {
        public string RestaurantName { get; set; }

        public CreateRestaurantCommand(string restaurantName)
        {
            RestaurantName = restaurantName;
        }
    }
}
