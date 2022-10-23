using AutoMapper;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Api.Auto.AutoMapper
{
    public class AddressAutoMapper : Profile
    {
        public AddressAutoMapper()
        {
            CreateMap<AddressDTO, Address>().ReverseMap();
        }
    }
}