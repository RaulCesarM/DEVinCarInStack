using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;


namespace DEVinCar.Domain.Services
{
    public class CityService : ICityService
    {

        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public IList<CityDTO> GetAll(Pagination pagination)
        {
            return _cityRepository
            .GetAll(pagination)
            .Select(x => new CityDTO(x))
            .ToList();
        }

        public CityDTO GetById(int id)
        {
           return new CityDTO(_cityRepository.GetById(id));
        }

        public int GetTotal()
        {
           return _cityRepository.GetTotal();
        }

        public void Insert(CityDTO entity)
        {
            _cityRepository.Insert(new City(entity));
        }

        public void Remove(int id)
        {
            var CityRemove = _cityRepository.GetById(id);
            _cityRepository.Remove(CityRemove);
        }

        public void Update(CityDTO entity, int id)
        {
           var CityUpdate = _cityRepository.GetById(entity.Id);
           CityUpdate.Update(entity);
           _cityRepository.Update(CityUpdate);
        }
    }
}