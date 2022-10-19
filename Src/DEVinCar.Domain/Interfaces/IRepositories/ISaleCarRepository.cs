
using DEVinCar.Domain.Interfaces.IBases;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Interfaces.IRepositories
{
    public interface ISaleCarRepository : IBaseRepository<SaleCar, int>
    {
        public bool CheckSaleCar(SaleCarDTO body, int saleId);
        
    }
}