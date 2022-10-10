using System;
using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.Entities.DTOs
{
    public class BuyDTO
    {
        [Required(ErrorMessage = "The SelleId is required.")]
        public int SellerId{ get; set; }
        public int BuyerId { get; set; }
        public DateTime SaleDate { get; set; }
    }
}


