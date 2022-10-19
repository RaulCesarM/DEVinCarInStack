using System;
using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.Entities.DTOs
{
    public class BuyDTO
    {        
        public int SellerId{ get; set; }
        public int BuyerId { get; set; }
        public DateTime SaleDate { get; set; }
    }
}


