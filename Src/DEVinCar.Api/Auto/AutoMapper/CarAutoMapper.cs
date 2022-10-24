using AutoMapper;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Api.Auto.AutoMapper
{
    public class CarAutoMapper : Profile
    {
        public CarAutoMapper()
        {
           CreateMap<CarDTO, Car>().ReverseMap();
        }
    }
}