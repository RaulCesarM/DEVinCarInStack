
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Entities.Models
{
    public class Sale
    {
        public int Id { get; internal set; }
        public DateTime SaleDate { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public virtual User UserBuyer { get; set; }
        public virtual User UserSeller { get; set; }
        public virtual List<SaleCar> Cars { get; set; }
        public virtual List<Delivery> Deliveries { get; set; }      
        public Sale()
        {
        } 
        public Sale(SaleDTO saleDTO)
        {   Id = saleDTO.Id;
            BuyerId = saleDTO.BuyerId;
            SaleDate = saleDTO.SaleDate;
        }

        public void Update(SaleDTO saleDTO)
        {
            
            BuyerId = saleDTO.BuyerId;
            SaleDate = saleDTO.SaleDate;
        }
      


    }
}