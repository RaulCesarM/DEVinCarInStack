
using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Infra.Data.Context;
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Infra.Data.Repository
{
    public class CityRepository : BaseGenericCrudRepository<City, int>, ICityRepository
    {
        private readonly DevInCarDbContext _context;
        public CityRepository(DevInCarDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetTotal()
        {
            return _context.Addresses.Count();
        }

        public bool Checked(int stateId, CityDTO city)
        {
            var state = _context.States.Find(stateId);

             if (_context.Cities.Any(c => c.StateId == state.Id && c.Name == city.Name))
            {
               return true;
            }
            return false;
        }

        public List<City> CitiesInSates(int stateId){
            var state = _context.States.Find(stateId);
            var cityStates = _context.Cities.Where(c => c.StateId == state.Id);

            return cityStates.ToList();
        }
    }
}