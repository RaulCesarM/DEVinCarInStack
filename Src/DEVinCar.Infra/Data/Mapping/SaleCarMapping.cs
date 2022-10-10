using DEVinCar.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCar.Infra.Data.Mapping
{
    public class SaleCarMapping : IEntityTypeConfiguration<SaleCar>
    {
        public void Configure(EntityTypeBuilder<SaleCar> entity)
        {
            entity.ToTable("SaleCars");
            entity.HasKey(sc => sc.Id);
            entity.Property(sc => sc.Id)
                .HasColumnType("int");

            entity.Property(sc => sc.SaleId)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(sc => sc.CarId)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(sc => sc.UnitPrice)
                .HasPrecision(18, 2);

            entity.Property(sc => sc.Amount)
                .HasColumnType("int");

            entity.HasOne<Car>(c => c.Car)
                .WithMany(c => c.Sales)
                .HasForeignKey(c => c.Id);

            entity.HasOne<Sale>(s => s.Sale)
                .WithMany(c => c.Cars)
                .HasForeignKey(s => s.Id);
        }
    }
}