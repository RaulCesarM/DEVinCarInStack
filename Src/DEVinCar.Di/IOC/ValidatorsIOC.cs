
using Microsoft.Extensions.DependencyInjection;

using FluentValidation.AspNetCore;
using DEVinCar.Domain.Validations.FluentValidations;
using FluentValidation;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;
using System.Reflection;

namespace DEVinCar.Di.IOC
{
    public static class ValidatorsIOC
    {       
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();         
           
            builder.AddTransient<IValidator<Address>, AddressValidators>();
            builder.AddTransient<IValidator<BuyDTO>, BuyDTOValidators>();
            builder.AddTransient<IValidator<CarDTO>, CarDTOValidators>();
            builder.AddTransient<IValidator<Car>,        CarValidators>();
            builder.AddTransient<IValidator<CityDTO>, CityDTOValidators>();
            builder.AddTransient<IValidator<SaleDTO>, SaleDTOValiadtors>();
            builder.AddTransient<IValidator<StateDTO>, StateDTOValidators>();
            builder.AddTransient<IValidator<UserDTO>, UserDTOValidators>();
        }
    }
}