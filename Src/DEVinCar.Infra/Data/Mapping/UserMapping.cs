using DEVinCar.Domain.Entities.Enuns;
using DEVinCar.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCar.Infra.Data.Mapping
{
    public class UserMapping: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Users");
            entity.HasKey(u => u.Id);
            entity
                .Property(u => u.Email)
                .HasMaxLength(150)
                .IsRequired();

            entity
                .Property(u => u.Password)
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(u => u.Name)
                .HasMaxLength(255)
                .IsRequired();

            entity
                .Property(u => u.BirthDate);
            entity
               .Property(u => u.Permission)
               .IsRequired();
            /*
            entity
                .HasData(new[] {
                    new User (1, "jose@email.com", "123456opp78", "Jose", new DateTime(2000, 12, 10), Permission.Administrador),
                    new User (2, "andrea@email.com", "987dasd654321", "Andrea", new DateTime(1999, 05, 11),Permission.Funcionario),
                    new User (3, "adao@email.com", "2589asd", "Adao", new DateTime(2005, 09, 02) ,Permission.Gerente),
                    new User (4, "monique@email.com", "asd45uio", "Monique", new DateTime(2001, 06, 07), Permission.Funcionario),
                });*/
        }
    }
}