using AutoMapper;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Api.Auto.AutoMapper
{
    public class DeliveryAutoMapper : Profile
    {
        public DeliveryAutoMapper()
        {
            CreateMap<DeliveryDTO, Delivery>().ReverseMap(); 
        }
    }
}