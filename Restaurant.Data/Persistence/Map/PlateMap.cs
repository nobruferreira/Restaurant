using Restaurant.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Restaurant.Data.Persistence.Map
{
    public class PlateMap : EntityTypeConfiguration<Plate>
    {
        public PlateMap()
        {
            ToTable("Plate");

            HasKey(x => x.PlateId);

            Property(x => x.PlateName)
                .HasMaxLength(80)
                .IsRequired();

            Property(x => x.Price)
               .IsRequired();

            HasRequired(x => x.Restaurant);
        }
    }
}
