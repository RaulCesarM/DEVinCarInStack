using DEVinCar.Domain.Entities.Models;
using DEVinCar.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DEVinCar.Infra.Data.Context
{
    public class DevInCarDbContext : DbContext
    {
       // private readonly IConfiguration _configuration;

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleCar> SaleCars { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Address> Addresses { get; set; }

        // public DevInCarDbContext(IConfiguration configuration)
        // {
        //     _configuration = configuration;
        // }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=BD_DEVINCAR;Trusted_Connection=True;");
         
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMapping());
            modelBuilder.ApplyConfiguration(new CarMapping());
            modelBuilder.ApplyConfiguration(new CityMapping());
            modelBuilder.ApplyConfiguration(new DeliveryMapping());
            modelBuilder.ApplyConfiguration(new SaleCarMapping());
            modelBuilder.ApplyConfiguration(new SaleMapping());
            modelBuilder.ApplyConfiguration(new StateMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
           
        }

       
    }
}