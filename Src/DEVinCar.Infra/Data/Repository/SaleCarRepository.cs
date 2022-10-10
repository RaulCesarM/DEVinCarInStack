
using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Infra.Data.Context;

namespace DEVinCar.Infra.Data.Repository
{
    public class SaleCarRepository : BaseGenericCrudRepository<SaleCar, int>, ISaleCarRepository
    {
        private readonly DevInCarDbContext _context;
        public SaleCarRepository(DevInCarDbContext context) : base(context)
        {
            _context = context;
        }


        public int GetTotal()
        {
            return _context.Addresses.Count();
        }
    }
}