
using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Infra.Data.Repository
{
    public class CarRepository : BaseGenericCrudRepository<Car, int>, ICarRepository
    {
        private readonly DevInCarDbContext _context;
        public CarRepository(DevInCarDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetTotal()
        {
            return _context.Cars.Count();
        }



        public IQueryable<Car> GetGeralViewCar(Pagination pagination)
        {
            return _context.Set<Car>()
                            .Take(pagination.Take)
                            .Skip(pagination.Skip)
                            .AsQueryable();
        }

       
    }
}