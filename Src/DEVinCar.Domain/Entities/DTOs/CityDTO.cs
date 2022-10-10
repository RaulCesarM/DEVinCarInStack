using System.ComponentModel.DataAnnotations;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Entities.DTOs
{
     public class CityDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]  
        public string Name { get; set; }

        public int StateId { get; set; }

        public CityDTO()
        {
            
        }
        public CityDTO(City city)
        {   Id = city.Id;
            Name = city.Name;
             StateId = city.StateId;
        }

       
       
    }
}