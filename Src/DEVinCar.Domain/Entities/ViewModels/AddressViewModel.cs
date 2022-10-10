
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Entities.ViewModels
{
    public class AddressViewModel
    {
        

        public int Id { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string Cep { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string CityName { get; set; }

        public AddressViewModel(int id, string street, int cityId, string cityName, int number, string complement, string cep)
        {
            Id = id;
            Street = street;
            CityId = cityId;
            CityName = cityName;
            Number = number;
            Complement = complement;
            Cep = cep;
        }

        public AddressViewModel(int id, string street, int cityId, int number, string complement, string cep)
        {
            Id = id;
            Street = street;
            CityId = cityId;
            Number = number;
            Complement = complement;
            Cep = cep;
        }
        public AddressViewModel(AddressDTO address)
        {
            Id=  address.Id;
            Street = address.Street;
            CityId = address.CityId;
            Number = address.Number;
            Complement = address.Complement;
            Cep = address.Cep;
        }

        public AddressViewModel(Address address)
        {
            Id = address.Id;
            Street = address.Street;
            CityId = address.CityId;
            Number = address.Number;
            Complement = address.Complement;
            Cep = address.Cep;
        }
    }
}
