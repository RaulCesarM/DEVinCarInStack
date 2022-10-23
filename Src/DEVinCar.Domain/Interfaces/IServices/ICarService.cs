using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IBases;

namespace DEVinCar.Domain.Interfaces.IServices
{
    public interface ICarService: IBaseService<CarDTO, int>
    {
        public IList<Car> GetGeralViewCar(
       string name,
        decimal? priceMin,
        decimal? priceMax);
        public IList<Car> GetGeralViewCarPage(
        string name,
         decimal? priceMin,
         decimal? priceMax,
         Pagination page);

        public Car GetCarById(int id);

        
    }
}