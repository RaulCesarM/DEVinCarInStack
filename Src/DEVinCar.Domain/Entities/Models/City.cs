

using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Entities.Models
{
    public class City
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public virtual State State { get; set; }

        public virtual List<Address> Addresses { get; set; }
        public City()
        {
            
        }

        public City(CityDTO  cityDTO)
        {
            Id = cityDTO.Id;
            StateId = cityDTO.StateId;
            Name= cityDTO.Name;
        }
        public void Update(CityDTO cityDTO)
        {

            Name = cityDTO.Name;
           
        }
    }
}