using AutoMapper;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Api.Auto.AutoMapper
{
    public class StateAutoMapper : Profile
    {
        public StateAutoMapper()
        {
            CreateMap<StateDTO, State>().ReverseMap();  
        }
    }
}