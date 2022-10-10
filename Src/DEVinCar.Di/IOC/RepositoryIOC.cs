using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Services;
using DEVinCar.Infra.Data.Context;
using DEVinCar.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DEVinCar.Di.IOC
{
    public class RepositoryIOC
    {
        public static void RegisterServices(IServiceCollection builder)
        {
    
            builder.AddDbContext<DevInCarDbContext>();
            
            builder.AddScoped<IAddressRepository, AddressRepository>();
            builder.AddScoped<ICarRepository, CarRepository>();
            builder.AddScoped<ICityRepository, CityRepository>();
            builder.AddScoped<IDeliveryRepository, DeliveryRepository>();
            builder.AddScoped<ISaleCarRepository, SaleCarRepository>();           
            builder.AddScoped<ISaleRepository, SaleRepository>();
            builder.AddScoped<IStateRepository, StateRepository>();
            builder.AddScoped<IUserRepository, UserRepository>();


            builder.AddScoped<IAddressService, AddressService>();
            builder.AddScoped<ICarService, CarService>();
            builder.AddScoped<ICityService, CityService>();
            builder.AddScoped<IDeliveryService, DeliveryService>();
            builder.AddScoped<ISaleCarService, SaleCarService>();
            builder.AddScoped<ISaleService, SaleService>();
            builder.AddScoped<IStateService, StateService>();
            builder.AddScoped<IUserService, UserService>();


        }
        
    }
}
