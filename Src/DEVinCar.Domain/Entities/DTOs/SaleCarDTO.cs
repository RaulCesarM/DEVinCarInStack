using System.ComponentModel.DataAnnotations;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Entities.DTOs
{
    public class SaleCarDTO
    {
        public int CarId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Amount { get; set; }
        public int SaleId { get; set; }

        public SaleCarDTO()
        {            
        }

        public SaleCarDTO(SaleCar saleCar)
        {
            CarId = saleCar.CarId;
            UnitPrice = saleCar.UnitPrice;
            Amount = saleCar.Amount;
            SaleId = saleCar.SaleId;
        }
    }
}
