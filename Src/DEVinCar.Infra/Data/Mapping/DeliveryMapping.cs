using DEVinCar.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCar.Infra.Data.Mapping
{
    public class DeliveryMapping : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> entity)
        {
            entity.ToTable("Deliveries");

            entity.HasKey(d => d.Id);

            entity.Property(d => d.Id)
                .HasColumnType("int");

            entity.Property(d => d.AddressId)
                .HasColumnType("int");

            entity
                .Property(d => d.SaleId)
                .HasColumnType("int");

            entity
                .Property(d => d.DeliveryForecast);


            entity.HasOne<Address>(a => a.Address)
                .WithMany(d => d.Deliveries)
                .HasForeignKey(a => a.AddressId);

            entity.HasOne<Sale>(s => s.Sale)
                .WithMany(d => d.Deliveries)
                .HasForeignKey(s => s.SaleId);

            entity.HasData(new []{
                new Delivery(1,  new DateTime(2000, 12, 10), 1, 10),
                new Delivery(2,  new DateTime(1999, 05, 11), 2, 9),
                new Delivery(3,  new DateTime(2005, 09, 12), 3, 8),
                new Delivery(4,  new DateTime(2001, 06, 12), 4, 7),
                new Delivery(5,  new DateTime(2011, 08, 11), 5, 6),
                new Delivery(6,  new DateTime(2008, 09, 01), 6, 5),
                new Delivery(7,  new DateTime(2005, 05, 06), 7, 4),
                new Delivery(8,  new DateTime(2002, 06, 01), 8, 3),
                new Delivery(9,  new DateTime(2000, 12, 03), 9, 2),
                new Delivery(10, new DateTime(2011, 10, 04), 10, 1),
            });
        }
    }

}