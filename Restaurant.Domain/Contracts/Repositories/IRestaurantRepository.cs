using Restaurant.Domain.Entities;
using System.Collections.Generic;

namespace Restaurant.Domain.Contracts.Repositories
{
    public interface IRestaurantRepository
    {
        List<_Restaurant> GetAll();
        _Restaurant GetById(int restaurantId);
        void Create(_Restaurant restaurant);
        void Remove(_Restaurant restaurant);
        void Update(_Restaurant restaurant);
    }
}
