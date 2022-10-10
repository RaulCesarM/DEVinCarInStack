
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Interfaces.IBases
{
    public interface IBaseRepository<TEntity, Tkey> where TEntity  : class
    {
        
        IList<TEntity> GetAll(Pagination pagination);
        TEntity GetById(Tkey id);
        void Insert(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        int GetTotal();
    }
}