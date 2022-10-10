

using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Interfaces.IBases
{
    public interface IBaseService<TEntity, Tkey> where TEntity : class
    {

        IList<TEntity> GetAll(Pagination pagination);
        TEntity GetById(Tkey id);
        void Insert(TEntity entity);
        void Remove(Tkey  id);
        void Update(TEntity entity, Tkey id);
        int GetTotal();
    }
}