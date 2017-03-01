using Restaurant.Domain.Commands.Restaurants;
using Restaurant.Domain.Entities;
using System.Collections.Generic;

namespace Restaurant.Domain.Contracts.Services
{
    public interface IRestaurantAppService
    {
        List<_Restaurant> GetAll();
        _Restaurant GetById(int restaurantId);
        _Restaurant Create(CreateRestaurantCommand command);
        _Restaurant Remove(int restaurantId);
        _Restaurant Update(UpdateRestaurantCommand command);
    }
}
