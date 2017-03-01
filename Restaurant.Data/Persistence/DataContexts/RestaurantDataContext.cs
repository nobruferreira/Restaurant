using Restaurant.Data.Persistence.Map;
using Restaurant.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Restaurant.Data.Persistence.DataContexts
{
    public class RestaurantDataContext : DbContext
    {
        public RestaurantDataContext() :
            base("EFRestaurant")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<_Restaurant> Restaurants { get; set; }
        public DbSet<Plate> Plates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties()
            .Where(p => p.Name == p.ReflectedType.Name + "Id")
            .Configure(p => p.IsKey());

            modelBuilder.Configurations.Add(new RestaurantMap());
            modelBuilder.Configurations.Add(new PlateMap());

            Database.SetInitializer<RestaurantDataContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
