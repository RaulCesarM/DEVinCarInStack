using System.ComponentModel.DataAnnotations;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Entities.DTOs
{
    public class AddressDTO
    {

        public int Id { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string Cep { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }

        public virtual City City { get; set; }
        public AddressDTO()
        {
            
        }

        public AddressDTO(Address address)
        {
        City = address.City;
        Id =  address.Id;    
        Street =address.Street;
        Cep = address.Cep;
        Number =address.Number;
        Complement =address.Complement;
         
        }
    }
}