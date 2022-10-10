using DEVinCar.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DEVinCar.Infra.Data.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Addresses");

            entity.HasKey(d => d.Id);

            entity.Property(d => d.CityId).HasColumnType("int").IsRequired();

            entity.Property(d => d.Street).HasMaxLength(150).IsRequired();

            entity.Property(d => d.Cep).HasMaxLength(8).IsRequired();

            entity.Property(d => d.Number).HasColumnType("int").IsRequired();

            entity.Property(d => d.Complement).HasMaxLength(255);

            entity.HasOne<City>(address => address.City)
            .WithMany(d => d.Addresses)
            .HasForeignKey(address => address.CityId)
            .IsRequired();
        }
    }
}