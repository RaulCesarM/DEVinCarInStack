using System.Security.AccessControl;
using System.ComponentModel.DataAnnotations;
using DEVinCar.Domain.Entities.Models;


namespace DEVinCar.Domain.Entities.DTOs
{
    public class CarDTO : BaseHateoas
    {
        public int? Id { get; set; }    
        public string Name { get; set; }
        public decimal SuggestedPrice { get; set; }

        public IList<HateoasDTO> Links { get; set; }
        

        public CarDTO()
        {
            
        }

        public CarDTO(Car car)
        {  Id = car.Id;        
            Name = car.Name;
            SuggestedPrice = car.SuggestedPrice;            
        }

       
    }
}
