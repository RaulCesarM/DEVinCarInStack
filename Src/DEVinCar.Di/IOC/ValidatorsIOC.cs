
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
           
            builder.AddScoped<IValidator<Address>, AddressValidators>();
            builder.AddScoped<IValidator<BuyDTO>, BuyDTOValidators>();
            builder.AddScoped<IValidator<CarDTO>, CarDTOValidators>();
            builder.AddScoped<IValidator<Car>,        CarValidators>();
            builder.AddScoped<IValidator<CityDTO>, CityDTOValidators>();
            builder.AddScoped<IValidator<SaleDTO>, SaleDTOValiadtors>();
            builder.AddScoped<IValidator<StateDTO>, StateDTOValidators>();
            builder.AddScoped<IValidator<UserDTO>, UserDTOValidators>();
        }
    }
}