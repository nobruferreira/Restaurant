using Restaurant.Domain.Contracts.Repositories;
using System.Linq;
using Restaurant.Domain.Entities;
using Restaurant.Data.Persistence.DataContexts;
using System.Data.Entity;
using Restaurant.Domain.Specs;
using System.Collections;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Data.Repositories
{
    public class PlateRepository : IPlateRepository
    {
        private RestaurantDataContext _context;

        public PlateRepository(RestaurantDataContext context)
        {
            _context = context;
        }

        public IEnumerable GetAll()
        {
            return (from p in _context.Plates
                    join r in _context.Restaurants on p.RestaurantId equals r.RestaurantId
                    select new { p.PlateId, p.PlateName, p.Price, r.RestaurantId, r.RestaurantName }).ToList();
        }
        
        public PlateVO GetByIdJoinDistinct(int plateId, int restaurantId)
        {
            return (from p in _context.Plates
            join r in _context.Restaurants on p.RestaurantId equals r.RestaurantId
            where p.PlateId == plateId
            where p.RestaurantId == restaurantId
            select new PlateVO()
            {
                PlateId = p.PlateId,
                PlateName = p.PlateName,
                Price = p.Price,
                RestaurantId = r.RestaurantId,
                RestaurantName = r.RestaurantName
            }).Distinct().FirstOrDefault();
        }

        public Plate GetById(int plateId, int restaurantId)
        {
            return _context.Plates.Where(PlateSpecs.GetPlateWithSomeRestaurant(plateId, restaurantId)).FirstOrDefault();
        }

        public void Create(Plate plate)
        {
            _context.Plates.Add(plate);
        }

        public void Remove(Plate plate)
        {
            _context.Plates.Remove(plate);
        }

        public void Update(Plate plate)
        {
            _context.Entry<Plate>(plate).State = EntityState.Modified;
        }
    }
}
