using Restaurant.Domain.Commands.Plates;
using Restaurant.Domain.Entities;
using System.Collections;

namespace Restaurant.Domain.Contracts.Services
{
    public interface IPlateAppService
    {
        IEnumerable GetAll();
        Plate GetById(int plateId, int restaurantId);
        Plate Create(CreatePlateCommand command);
        Plate Remove(RemovePlateCommand command);
        Plate Update(UpdatePlateCommand command);
    }
}
