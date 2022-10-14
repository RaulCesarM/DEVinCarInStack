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

            entity.HasData(new []{
                //id price amount carid, sale id
                new SaleCar(1,   60000M, 1,1,1 ),
                new SaleCar(2,   20000M, 1,2,2 ),
                new SaleCar(3,   30000M, 1,3,3 ),
                new SaleCar(4,   60000M, 3,1,4 ),
                new SaleCar(5,   20000M, 1,4,5 ),
                new SaleCar(6,   50000M, 1,7,6 ),
                new SaleCar(7,   70000M, 2,9,7 ),
                new SaleCar(8,   10000M, 1,6,8 ),
                new SaleCar(9,   30000M, 2,3,9 ),
                new SaleCar(10,  70000M, 1,9,10 ),





            });
        }
    }
}