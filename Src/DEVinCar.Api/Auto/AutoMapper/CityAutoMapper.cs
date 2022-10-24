using AutoMapper;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Api.Auto.AutoMapper
{
    public class CityAutoMapper : Profile
    {
      public CityAutoMapper()
      {
            CreateMap<CityDTO, City>().ReverseMap();
      }  
    }
}