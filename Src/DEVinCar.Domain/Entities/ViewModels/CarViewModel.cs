
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Entities.ViewModels
{

    public class CarViewModel
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int? Amount { get; set; }
        public decimal Total { get; set; }
        public CarViewModel()
        {
        }

        public CarViewModel(Car car)
        {
            Name = car.Name;            
            
        }
    }
}