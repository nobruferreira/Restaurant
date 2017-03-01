using Restaurant.Domain.Scopes.Restaurants;

namespace Restaurant.Domain.Entities
{
    public class _Restaurant
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }

        public _Restaurant()
        {
                
        }

        public _Restaurant(string name)
        {
            RestaurantName = name;
        }

        public void Create()
        {
            if (!this.CreateRestaurantScopeIsValid())
                return;
        }

        public void Update(string name)
        {
            if (!this.UpdateRestaurantScopeIsValid(name))
                return;

            RestaurantName = name;
        }
    }
}
