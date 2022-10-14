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
            
            entity
                .HasData(new[] {
                    new User (1, "jose@email.com",    "123456opp78dfg", "Jose",   new DateTime(2000, 12, 10), Permission.Administrador),
                    new User (2, "andrea@email.com",  "987dasd654321d", "Andrea", new DateTime(1999, 05, 11), Permission.Funcionario),
                    new User (3, "adao@email.com",    "2589as89898ddf", "Adao",   new DateTime(2005, 09, 12) ,Permission.Gerente),
                    new User (4, "andre@email.com",   "asasdd45uiodfg", "andre",  new DateTime(2001, 06, 12), Permission.Gerente),
                    new User (5, "Marcos@email.com",  "asd45uidfg121o", "Marcos", new DateTime(2011, 08, 11), Permission.Funcionario),
                    new User (6, "Manuela@email.com", "asd45dfgu789io", "Manuela",new DateTime(2008, 09, 01), Permission.Funcionario),
                    new User (7, "Vania@email.com",   "asd454563213ui", "Vania",  new DateTime(2005, 05, 06), Permission.Funcionario),
                    new User (8, "carla@email.com",   "asdfgd45ui121o", "carla",  new DateTime(2002, 06, 01), Permission.Funcionario),
                    new User (9, "Malena@email.com",  "asd45ui898odfg", "Malena", new DateTime(2000, 12, 03), Permission.Funcionario),
                    new User (10, "Marize@email.com", "asd45uidfgdfgo", "Marize", new DateTime(2011, 10, 04), Permission.Funcionario),
                   
                });
        }
    }
}