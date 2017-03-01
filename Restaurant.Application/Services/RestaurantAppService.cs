using System.Collections.Generic;
using Restaurant.Domain.Contracts.Services;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Contracts.Repositories;
using Restaurant.Data.Persistence.UoW;
using Restaurant.Domain.Commands.Restaurants;
using System;

namespace Restaurant.Application.Services
{
    public class RestaurantAppService : ApplicationServiceBase, IRestaurantAppService
    {
        private IRestaurantRepository _repository;

        public RestaurantAppService(IRestaurantRepository respository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = respository;
        }

        public List<_Restaurant> GetAll()
        {
            return _repository.GetAll();
        }

        public _Restaurant GetById(int restaurantId)
        {
            return _repository.GetById(restaurantId);
        }

        public _Restaurant Create(CreateRestaurantCommand command)
        {
            var restaurant = new _Restaurant(command.RestaurantName);
            restaurant.Create();
            _repository.Create(restaurant);

            if (Commit())
                return restaurant;

            return null;
        }

        public _Restaurant Remove(int restaurantId)
        {
            var restaurant = _repository.GetById(restaurantId);

            if (restaurant == null)
                return null;

            _repository.Remove(restaurant);

            if (Commit())
                return restaurant;

            return null;
        }

        public _Restaurant Update(UpdateRestaurantCommand command)
        {
            var restaurant = _repository.GetById(command.RestaurantId);

            if (restaurant == null)
                return null;

            restaurant.Update(command.RestaurantName);
            _repository.Update(restaurant);

            if (Commit())
                return restaurant;

            return null;
        }
    }
}
