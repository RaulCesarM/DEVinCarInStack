

using DEVinCar.Domain.Interfaces.IBases;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Interfaces.IRepositories
{
    public interface IStateRepository : IBaseRepository<State, int>
    {
        public IQueryable<State> GetGeralViewState();
    }
}