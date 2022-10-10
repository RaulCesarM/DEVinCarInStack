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
        }
    }

}