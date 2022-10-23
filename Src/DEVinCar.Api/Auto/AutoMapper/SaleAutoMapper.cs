using AutoMapper;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Api.Auto.AutoMapper
{
    public class SaleAutoMapper : Profile
    {
        public SaleAutoMapper()
        {
            CreateMap<SaleDTO, Sale>().ReverseMap(); 
        }
    }
}