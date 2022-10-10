
using DEVinCar.Domain.Interfaces.IBases;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Interfaces.IRepositories
{
    public interface ICityRepository : IBaseRepository<City, int>
    {
        public bool Checked(int stateId, CityDTO city);
        public List<City> CitiesInSates(int stateId);
       
    }
}