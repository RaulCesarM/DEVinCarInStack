
using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Infra.Data.Context;
using DEVinCar.Domain.Entities.DTOs;

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

        public bool  CheckSaleCar(SaleCarDTO body, int saleId){

              if (_context.Cars.Any(c => c.Id == body.CarId) && _context.Sales.Any(s => s.Id == body.SaleId)){
                return true;
              }else{
                return false;
              }
        }


    }
}