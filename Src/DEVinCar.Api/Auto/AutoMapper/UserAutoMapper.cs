using AutoMapper;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Api.Auto.AutoMapper
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<UserDTO, User>().ReverseMap(); 
        }
    }
}