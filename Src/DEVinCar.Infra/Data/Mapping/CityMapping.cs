using DEVinCar.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCar.Infra.Data.Mapping
{
    public class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> entity)
        {
            entity.ToTable("Cities");
            entity.HasKey(a => a.Id);
            entity
                .Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired();
            entity
                .Property(a => a.StateId)
                .HasColumnType("int")
                .IsRequired();
            entity
                .HasOne<State>(city => city.State)
                .WithMany(s => s.Cities)
                .HasForeignKey(city => city.StateId)
                .IsRequired();

                entity.HasData(new[]{
                    new City(1, "Jaragua do sul", 24),
                    new City(2, "Joinville",      24),
                    new City(3, "Florianopolis",  24),
                    new City(4, "Lages",          24),
                    new City(5, "São Paulo",      25),
                    new City(6, "Maringá",        16),
                    new City(7, "Curitiba",       16),
                    new City(8, "Manaus",          4),
                    new City(9, "Porto Alegre",   21),
                    new City(10,"Charqueadas",    21),
                });
        }
    }
}