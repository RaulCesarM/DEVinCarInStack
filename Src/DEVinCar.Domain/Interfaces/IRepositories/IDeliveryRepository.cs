
using DEVinCar.Domain.Interfaces.IBases;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Interfaces.IRepositories
{
    public interface IDeliveryRepository : IBaseRepository<Delivery, int>
    {
        public Delivery GetRealtion(int addressId);
        public IQueryable<Delivery> GetQuerable(Pagination pagination);
        public IQueryable<Delivery> GetQuerable();
    }
}