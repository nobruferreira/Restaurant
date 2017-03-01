using Restaurant.Domain.Contracts.Repositories;
using System.Collections.Generic;
using System.Linq;
using Restaurant.Domain.Entities;
using Restaurant.Data.Persistence.DataContexts;
using System.Data.Entity;


namespace Restaurant.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private RestaurantDataContext _context;

        public RestaurantRepository(RestaurantDataContext context)
        {
            _context = context;
        }

        public List<_Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(x => x.RestaurantName).ToList();
        }

        public _Restaurant GetById(int restaurantId)
        {
            return _context.Restaurants.Find(restaurantId);
        }

        public void Create(_Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
        }

        public void Remove(_Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
        }

        public void Update(_Restaurant restaurant)
        {
            _context.Entry<_Restaurant>(restaurant).State = EntityState.Modified;
        }
    }
}
