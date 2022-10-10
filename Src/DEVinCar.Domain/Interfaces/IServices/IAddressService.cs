
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.ViewModels;
using DEVinCar.Domain.Interfaces.IBases;


namespace DEVinCar.Domain.Interfaces.IServices
{
    public interface IAddressService : IBaseService<AddressDTO, int>
    {
        IList<AddressViewModel> GetGeralViewAddress(int? cityId,
                                            int? stateId,
                                            string street,
                                            string cep);

        public int PostAdress(int stateId, int cityId, AddressDTO body);

        public List<GetCityByIdViewModel> GetCityByStateId(int stateId, string name);
        public GetCityByIdViewModel GetCityById(int stateId, int cityId);

        public AddressViewModel PatchAdressService(AddressDTO address, AddressPatchDTO addressPatchDTO);
    }
}