using Restaurant.Domain.Entities;
using Restaurant.SharedKernel.Validation;

namespace Restaurant.Domain.Scopes.Restaurants
{
    public static class RestaurantScopes
    {
        public static bool CreateRestaurantScopeIsValid(this _Restaurant restaurant)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(restaurant.RestaurantName, "O nome do restaurante é obrigatório")
            );
        }

        public static bool UpdateRestaurantScopeIsValid(this _Restaurant restaurant, string restaurantName)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(restaurantName, "O nome do restaurante é obrigatório")
            );
        }
    }
}
