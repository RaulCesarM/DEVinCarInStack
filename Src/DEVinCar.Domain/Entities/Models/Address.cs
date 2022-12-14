
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Entities.Models
{
    public class Address
    {
       

        public int Id { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string Cep { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
      

       public virtual City City { get; set; }

       public virtual List<Delivery> Deliveries { get; set; }

       public Address()
       {        
       }
       public Address(AddressDTO addressDTO)
       {     
            Street = addressDTO.Street;
            Cep = addressDTO.Cep ;
            Number = addressDTO.Number;
            Complement = addressDTO.Complement;        
       }

        public Address(int id, int cityId, string street, string cep, int number, string complement)
        {
            Id = id;
            CityId = cityId;
            Street = street;
            Cep = cep;
            Number = number;
            Complement = complement;
        }

        public void Update(AddressDTO addressDTO)
        {
            Street = addressDTO.Street;
            Cep = addressDTO.Cep;
            Number = addressDTO.Number;
            Complement = addressDTO.Complement;
        }
    }
}