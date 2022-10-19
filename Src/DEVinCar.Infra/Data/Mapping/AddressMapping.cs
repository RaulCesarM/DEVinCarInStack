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

            entity.HasData(new []{
                //id address, id city
                new Address(1, 1, "Bertha weege" , "89260200", 55 ,  "avenida dos javeiros"),
                new Address(2, 2, "Macarena    " , "99260450", 44 ,  "bóson de higgs"),
                new Address(3, 3, "Mundial frei" , "88245640", 787 , "rutherford bohr "),
                new Address(4, 4, "Alvin Bross"  , "79260500", 554 , "paradoxo dos gemeos"),
                new Address(5, 5, "Nickson nelma", "87289890", 578 , "paradoxo de bootstrap"),
                new Address(6, 6, "jk matilda"   , "49245500", 544 , "gato de schrödinger"),
                new Address(7, 7, "horizons blue", "89567520", 33 ,  "efeito fantasmagorico"),
                new Address(8, 8, "apargatas"    , "84256500", 323 , "max plank"),
                new Address(9, 9, "medianeira"   , "86260560", 678 , "stephen hawking"),
                new Address(10, 10, "bartinduum" , "89960450", 123 , "de volta para o futuro"),
            });
        }
    }
}