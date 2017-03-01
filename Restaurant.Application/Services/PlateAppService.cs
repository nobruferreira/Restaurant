using Restaurant.Domain.Contracts.Services;
using System.Collections.Generic;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Contracts.Repositories;
using Restaurant.Data.Persistence.UoW;
using Restaurant.Domain.Commands.Plates;
using System.Collections;
using System;
using Restaurant.Domain.ValueObjects;

namespace Restaurant.Application.Services
{
    public class PlateAppService : ApplicationServiceBase, IPlateAppService
    {
        private IPlateRepository _repository;

        public PlateAppService(IPlateRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repository;
        }

        public IEnumerable GetAll()
        {
            return _repository.GetAll();
        }

        public Plate GetById(int plateId, int restaurantId)
        {
            return _repository.GetById(plateId, restaurantId);
        }

        public Plate Create(CreatePlateCommand command)
        {
            var plate = new Plate(command.PlateName, command.Price, command.RestaurantId);
            plate.Create();
            _repository.Create(plate);

            if (Commit())
                return plate;

            return null;
        }

        public Plate Remove(RemovePlateCommand command)
        {
            var plate = _repository.GetById(command.PlateId, command.RestaurantId);

            if (plate == null)
                return null;

            _repository.Remove(plate);

            if (Commit())
                return plate;

            return null;
        }

        public Plate Update(UpdatePlateCommand command)
        {
            var plate = _repository.GetById(command.PlateId, command.RestaurantId);

            if (plate == null)
                return null;

            plate.Update(command.PlateName, command.Price, command.RestaurantId);
            _repository.Update(plate);

            if (Commit())
                return plate;

            return null;
        }
    }
}
