using Restaurant.Domain.Entities;
using Restaurant.Domain.ValueObjects;
using System.Collections;
using System.Collections.Generic;

namespace Restaurant.Domain.Contracts.Repositories
{
    public interface IPlateRepository
    {
        IEnumerable GetAll();
        PlateVO GetByIdJoinDistinct(int plateId, int restaurantId);
        Plate GetById(int plateId, int restaurantId);
        void Create(Plate plate);
        void Remove(Plate plate);
        void Update(Plate plate);
    }
}
