
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.ViewModels;
using DEVinCar.Domain.Interfaces.IBases;


namespace DEVinCar.Domain.Interfaces.IRepositories
{
    public interface IAddressRepository : IBaseRepository<Address, int>
    {
        public IQueryable<Address> GetGeralViewAddress();

       

    
    }

}

