using Restaurant.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Restaurant.Data.Persistence.Map
{
    public class RestaurantMap : EntityTypeConfiguration<_Restaurant>
    {
        public RestaurantMap()
        {
            ToTable("Restaurant");

            HasKey(x => x.RestaurantId);

            Property(x => x.RestaurantName)
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}
