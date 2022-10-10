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
                
        }
    }
}