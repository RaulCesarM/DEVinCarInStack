using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Infra.Data.Repository
{
    public class DeliveryRepository : BaseGenericCrudRepository<Delivery, int>, IDeliveryRepository
    {
        private readonly DevInCarDbContext _context;
        public DeliveryRepository(DevInCarDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetTotal()
        {
            return _context.Addresses.Count();
        }
        public Delivery GetRealtion(int addressId)
        {
            return _context.Deliveries.FirstOrDefault(d => d.AddressId == addressId);
        }

        public IQueryable<Delivery> GetQuerable()
        {
            return _context.Set<Delivery>().AsQueryable();
        }

        public IQueryable<Delivery> GetQuerable(Pagination pagination)
        {
            return _context.Set<Delivery>()
                           .Take(pagination.Take)
                           .Skip(pagination.Skip)
                           .AsQueryable();
        }
    }
}
