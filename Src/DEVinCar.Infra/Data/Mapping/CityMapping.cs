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
        }
    }
}