using System.ComponentModel.DataAnnotations;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Entities.DTOs
{
    public class SaleDTO
    {
        public int Id {get;internal set;}        
        public int BuyerId { get; set; }
        public DateTime SaleDate { get; set; }

        public SaleDTO()
        {            
        }

        public SaleDTO(Sale sale)
        {   Id = sale.Id;
            BuyerId = sale.BuyerId;
            SaleDate = sale.SaleDate;
        }
    }
}
