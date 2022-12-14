
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Entities.Models
{
    public class SaleCar
    {
        public int Id { get; internal set; }
        public decimal? UnitPrice { get; set; }
        public int? Amount { get; set; }
        public int CarId { get; set; }
        public int SaleId { get; set; }
        public virtual Car Car { get; set; }
        public virtual Sale Sale { get; set; }
        public SaleCar()
        {
        }

        public SaleCar(SaleCarDTO saleCarDTO)
        {
            CarId = saleCarDTO.CarId;
            UnitPrice = saleCarDTO.UnitPrice;
            Amount = saleCarDTO.Amount;
            SaleId = saleCarDTO.SaleId;
        }

        public SaleCar(int _Id, decimal _UnitPrice, int _Amount, int _CarId, int _SaleId)
        {
            Id=_Id;
            UnitPrice =_UnitPrice;
            Amount =_Amount;
            CarId = _CarId;
            SaleId =_SaleId;


        }

        public void Update(SaleCarDTO saleCarDTO)
        {
            CarId = saleCarDTO.CarId;
            UnitPrice = saleCarDTO.UnitPrice;
            Amount = saleCarDTO.Amount;
            SaleId = saleCarDTO.SaleId;
        }



        public decimal Sum(decimal UnitPrice, int? Amount)
        {
            return UnitPrice * (int)Amount;
        }
    }
}