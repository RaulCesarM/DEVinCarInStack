using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Entities.DTOs;

public class DeliveryDTO
{
    public int Id { get;internal set; }
    public int AddressId { get; set; }
    public DateTime? DeliveryForecast { get; set; }
    public DeliveryDTO()
    {
        
    }

    public DeliveryDTO(Delivery delivery)
    {
        Id = delivery.Id;
        AddressId =delivery.AddressId;
        DeliveryForecast = delivery.DeliveryForecast;
    }
}