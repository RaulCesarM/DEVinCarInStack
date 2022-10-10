
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IBases;


namespace DEVinCar.Domain.Interfaces.IServices
{
    public interface IDeliveryService : IBaseService<DeliveryDTO, int>
    {
        public IList<Delivery> GetDelivery(int? addressId, int? saleId);
    }
}