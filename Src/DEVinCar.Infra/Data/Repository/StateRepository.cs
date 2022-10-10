using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Infra.Data.Repository
{
    public class StateRepository : BaseGenericCrudRepository<State, int>, IStateRepository
    {
        private readonly DevInCarDbContext _context;
        public StateRepository(DevInCarDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetTotal()
        {
            return _context.Addresses.Count();
        }

        public IQueryable<State> GetGeralViewState()
        {
            return _context.Set<State>().Include(a => a.Cities).AsQueryable();
        }
    }
}