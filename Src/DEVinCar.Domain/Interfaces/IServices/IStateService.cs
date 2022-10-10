
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.ViewModels;
using DEVinCar.Domain.Interfaces.IBases;

namespace DEVinCar.Domain.Interfaces.IServices
{
    public interface IStateService : IBaseService<StateDTO, int>
    {

        public int PostCity(int stateId, CityDTO cityDTO);

        public List<GetStateViewModel> GetStateByName(string name);
        
    }
}