using Restaurant.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Restaurant.Domain.Specs
{
    public static class PlateSpecs
    {
        public static Expression<Func<Plate, bool>> GetPlateWithSomeRestaurant(int plateId, int restaurantId)
        {
            return x => x.PlateId == plateId && x.RestaurantId == restaurantId;
        }
    }
}
