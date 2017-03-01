using Restaurant.Domain.Scopes.Plates;

namespace Restaurant.Domain.Entities
{
    public class Plate
    {
        public int PlateId { get; private set; }
        public string PlateName { get; private set; }
        public decimal Price { get; private set; }
        public int RestaurantId { get; set; }
        public _Restaurant Restaurant { get; set; }

        public Plate()
        {
                
        }

        public Plate(string name, decimal price, int restaurantId)
        {
            PlateName = name;
            Price = price;
            RestaurantId = restaurantId;
        }

        public void Create()
        {
            if (!this.CreatePlateScopeIsValid())
                return;
        }

        public void Update(string name, decimal price, int restaurantId)
        {
            if (!this.UpdatePlateScopeIsValid(name, price, restaurantId))
                return;

            PlateName = name;
            Price = price;
            RestaurantId = restaurantId;
        }
    }
}
