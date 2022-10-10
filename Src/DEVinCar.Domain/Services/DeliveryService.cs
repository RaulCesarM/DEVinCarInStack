using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Validations.Exceptions;

namespace DEVinCar.Domain.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository= deliveryRepository;
        }
        public IList<DeliveryDTO> GetAll(Pagination pagination)
        {
          return _deliveryRepository
          .GetAll(pagination)
          .Select(x => new DeliveryDTO(x))
          .ToList();
          
        }

        public DeliveryDTO GetById(int id)
        {
            return new DeliveryDTO(_deliveryRepository.GetById(id));
        }

        public int GetTotal()
        {
           return _deliveryRepository.GetTotal();
        }

        public void Insert(DeliveryDTO entity)
        {
            _deliveryRepository.Insert(new Delivery(entity));
        }

        public void Remove(int id)
        {
           var DeliveryRemove = _deliveryRepository.GetById(id);
           _deliveryRepository.Remove(DeliveryRemove);
        }

        public void Update(DeliveryDTO entity, int id)
        {
            var DeliveryUpdate = _deliveryRepository.GetById(entity.Id);
            DeliveryUpdate.Update(entity);
            _deliveryRepository.Update(DeliveryUpdate);
        }

        public IList<Delivery> GetDelivery(int? addressId, int? saleId){

            var query = _deliveryRepository.GetQuerable();

            if (addressId.HasValue)
            {
                query = query.Where(a => a.AddressId == addressId);
            }

            if (saleId.HasValue)
            {
                query = query.Where(s => s.SaleId == saleId);
            }

            if (!query.ToList().Any())
            {
                throw new NotFoundException($"The Delivery with addressId:{addressId} end addressId: {saleId} not found.");
            }
            return query.ToList();
        }


    }
}