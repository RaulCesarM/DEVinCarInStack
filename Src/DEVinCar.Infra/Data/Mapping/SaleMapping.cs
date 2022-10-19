using DEVinCar.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCar.Infra.Data.Mapping
{
    public class SaleMapping : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> entity)
        {
            entity.ToTable("Sales");
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Id)
                .HasColumnType("int");

            entity.Property(s => s.SaleDate);


            entity.HasOne(u => u.UserBuyer)
                .WithMany()
                .HasForeignKey(u => u.BuyerId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(u => u.UserSeller)
                .WithMany()
                .HasForeignKey(u => u.SellerId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasData(new[]{
                new Sale(1, new DateTime(2021, 12, 12), 1 , 2),
                new Sale(2, new DateTime(2021, 12, 12), 3 , 4),
                new Sale(3, new DateTime(2021, 12, 12), 5 , 6),
                new Sale(4, new DateTime(2021, 12, 12), 7 , 8),
                new Sale(5, new DateTime(2021, 12, 12), 9 , 10),
                new Sale(6, new DateTime(2021, 12, 12), 3 , 2),
                new Sale(7, new DateTime(2021, 12, 12), 5 , 4),
                new Sale(8, new DateTime(2021, 12, 12), 7, 6),
                new Sale(9, new DateTime(2021, 12, 12), 9 , 8),
                new Sale(10, new DateTime(2021, 12, 12), 1 , 10),  

            });
                
        }
    }
}