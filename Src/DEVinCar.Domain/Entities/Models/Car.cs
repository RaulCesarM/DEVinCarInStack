

using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Entities.Models
{
    public class Car
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public decimal SuggestedPrice { get; set; }
        public virtual List<SaleCar> Sales { get; set; }
        public Car()
        {
        }
        public Car(Car car)
        {
            Id = car.Id;
            Name = car.Name;
            SuggestedPrice = car.SuggestedPrice;

        }
        public Car(int id, string name, decimal suggestedPrice)
        {
            Id = id;
            Name = name;
            SuggestedPrice = suggestedPrice;
        } 
        public Car(CarDTO carDTO)
        {
           
            Name = carDTO.Name;
            SuggestedPrice = carDTO.SuggestedPrice;
        }

        public void Update(CarDTO carDTO)
        {
          
            Name = carDTO.Name;
            SuggestedPrice = carDTO.SuggestedPrice;
        }
    }
}