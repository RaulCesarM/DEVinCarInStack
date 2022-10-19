
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Entities.Models
{
    public class Delivery
    {
        public int Id { get; internal set; }
        public DateTime? DeliveryForecast { get; set; }
        public int AddressId { get; set; }
        public int SaleId { get; set; }
        public virtual Address Address { get; set; }
        public virtual Sale Sale { get; set; }
        public Delivery()
        {
        }
        public Delivery(DeliveryDTO deliveryDTO)
        {
            Id = deliveryDTO.Id;
            AddressId = deliveryDTO.AddressId;
            DeliveryForecast = deliveryDTO.DeliveryForecast;
        }

        public Delivery(int id, DateTime dateTime, int addressId, int saleId)
        {
            Id= id;
            DeliveryForecast = dateTime;
            AddressId = addressId;
            SaleId = saleId;

        }

        public void Update(DeliveryDTO deliveryDTO)
        {
            Id = deliveryDTO.Id;
            AddressId = deliveryDTO.AddressId;
            DeliveryForecast = deliveryDTO.DeliveryForecast;
        }
    }
}