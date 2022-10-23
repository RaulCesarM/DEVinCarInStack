using AutoMapper;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;


namespace DEVinCar.Api.Auto.AutoMapper
{
    public class SaleCarAutoMapper : Profile
    {
        public SaleCarAutoMapper()
        {
            CreateMap<SaleCarDTO, SaleCar>().ReverseMap();
        }
    }
}