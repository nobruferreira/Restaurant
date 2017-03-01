using Restaurant.SharedKernel;
using Microsoft.Practices.Unity;
using Restaurant.Domain.Contracts.Services;
using Restaurant.Application.Services;
using Restaurant.Data.Repositories;
using Restaurant.Domain.Contracts.Repositories;
using Restaurant.Data.Persistence.DataContexts;
using Restaurant.Data.Persistence.UoW;

namespace Restaurant.CrossCutting
{
    public static class DependencyRegister
    {
        /// <summary>
        /// TransientLifetimeManager - Cada Resolve(RegisterType) gera uma nova instância.
        /// HierarchicalLifetimeManager - Utiliza Singleton
        /// </summary>
        /// <param name="container"></param>
        public static void Register(UnityContainer container)
        {
            container.RegisterType<RestaurantDataContext, RestaurantDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            container.RegisterType<IRestaurantRepository, RestaurantRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlateRepository, PlateRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IRestaurantAppService, RestaurantAppService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPlateAppService, PlateAppService>(new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
        }
    }
}
