using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;

using DEVinCar.Domain.Validations.Exceptions;
using DEVinCar.Domain.Interfaces.IBases;

namespace DEVinCar.Domain.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public IList<CarDTO> GetAll(Pagination pagination)
        {
            return _carRepository
            .GetAll(pagination)
            .Select(x => new CarDTO(x))
            .ToList();
        }

        public Car GetCarById(int id)
        {
            if(id <= 0){
               throw new IncorrectInputMessageException($"The incorrect value in price.");
            }
            var car =_carRepository.GetById(id);
            if (car == null){
              throw new NotFoundException($"The car with ID: {id} not find");
            } 
            return car;
        }


        public int GetTotal()
        {
            return _carRepository.GetTotal();
        }

        public void Insert(CarDTO entity)
        {
           

            if(entity.Name == "" || entity.SuggestedPrice<=0)
            {
                throw new IncorrectInputMessageException($"The incorrect value object id.");
            }
            _carRepository.Insert(new Car(entity));
        }

        public void Remove(int id)
        {
           var CarRemove = _carRepository.GetById(id);
           if(CarRemove == null){
                throw new IncorrectInputMessageException($"The incorrect value object id.");
           }
            _carRepository.Remove(CarRemove);
        }



        public void Update(CarDTO entity, int id)
        {
            var CarUpdate = _carRepository.GetById(id);

            if (CarUpdate == null)
                throw new IncorrectInputMessageException($"The incorrect value object id.");
            if (entity.Name.Equals(null) || entity.SuggestedPrice.Equals(null))
                throw new IncorrectInputMessageException($"Error in name or Price");
            if (entity.SuggestedPrice <= 0)
                throw new IncorrectInputMessageException($" Price not accept");


            CarUpdate.Update(entity);
            _carRepository.Update(CarUpdate);
        }



        public IList<Car> GetGeralViewCarPage(string name,
                                        decimal? priceMin,
                                        decimal? priceMax,
                                        Pagination page)
        {
            var query = _carRepository.GetGeralViewCar(page);
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }
            if (priceMin > priceMax)
            {
                throw new IncorrectInputMessageException($"The incorrect value in price.");
            }
            if (priceMin.HasValue)
            {
                query = query.Where(c => c.SuggestedPrice >= priceMin);
            }
            if (priceMax.HasValue)
            {
                query = query.Where(c => c.SuggestedPrice <= priceMax);
            }
            if (!query.ToList().Any())
            {
                throw new IncorrectInputMessageException($"The input incorrect.");
            } 
            List<Car> carViewList = new List<Car>();
            query.ToList().ForEach(car =>{
                carViewList.Add(new Car(car));
            });
            return carViewList;
        }

        public CarDTO GetById(int id)
        {
            return new CarDTO(_carRepository.GetById(id));
        }

        public IList<Car> GetGeralViewCar(string name, decimal? priceMin, decimal? priceMax)
        {
            throw new NotImplementedException();
        }
    }
}