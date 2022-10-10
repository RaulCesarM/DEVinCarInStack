using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;
using DEVinCar.Domain.Entities.ViewModels;
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Infra.Data.Repository
{
    public class AddressRepository : BaseGenericCrudRepository<Address, int>, IAddressRepository
    {
        private readonly DevInCarDbContext _context;
        public AddressRepository(DevInCarDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetTotal()
        {
           return _context.Addresses.Count();
        }

        public IQueryable<Address> GetGeralViewAddress(){
            return _context.Set<Address>().Include(a => a.City).AsQueryable();
        }

      
    }

}