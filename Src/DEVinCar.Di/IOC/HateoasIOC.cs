
using DEVinCar.Domain.HateoasServices;
using DEVinCar.Domain.Interfaces.IHateoas;
using Microsoft.Extensions.DependencyInjection;

namespace DEVinCar.Di.IOC
{
    public static class HateoasIOC
    {
        public static void RegisterServices(IServiceCollection builder)
        {
          

            builder.AddScoped<IAdddressHateoasServices, AddressHateoasServices>();
            builder.AddScoped<ICarHateoasServices, CarHateoasServices>();
            builder.AddScoped<ICityHateoasServices, CityHateoasServices>();
            builder.AddScoped<IDeliveryHateoasServices, DeliveryHateoasServices>();
            builder.AddScoped<ISaleCarHateoasServices, SaleCarHateoasServices>();
            builder.AddScoped<ISaleHateoasServices, SaleHateoasService>();
            builder.AddScoped<IStateHateoasServices, StateHateoasServices>();
            builder.AddScoped<IUserHateoasServices, UserHateoasServices>();
          
          
        }
    }
}