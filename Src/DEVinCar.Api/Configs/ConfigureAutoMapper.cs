
using AutoMapper;
using DEVinCar.Api.Auto.AutoMapper;

namespace DEVinCar.Api.Configs
{
    public static class ConfigureAutoMapper
    {
        public static IMapper Configure()
        {
            var configMap = new MapperConfiguration(config =>
            {
                config.AddProfile(new AddressAutoMapper());
                config.AddProfile(new CarAutoMapper());
                config.AddProfile(new CityAutoMapper());
                config.AddProfile(new DeliveryAutoMapper());
                config.AddProfile(new SaleAutoMapper());
                config.AddProfile(new SaleCarAutoMapper());
                config.AddProfile(new StateAutoMapper());
                config.AddProfile(new UserAutoMapper());
                
            });
            return configMap.CreateMapper(); 
        }
    }
}