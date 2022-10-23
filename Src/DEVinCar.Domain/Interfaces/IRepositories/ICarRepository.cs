
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IBases;


namespace DEVinCar.Domain.Interfaces.IRepositories
{
    public interface ICarRepository : IBaseRepository<Car, int>
    {

        public IQueryable<Car> GetGeralViewCar(Pagination pagination);
      
    }
}