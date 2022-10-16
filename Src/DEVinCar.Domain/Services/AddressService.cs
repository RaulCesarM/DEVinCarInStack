
using System.Linq;
using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.ViewModels;
using DEVinCar.Domain.Validations.Exceptions;

namespace DEVinCar.Domain.Services
{

    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        public AddressService(
        IAddressRepository addressRepository,
        IDeliveryRepository deliveryRepository,
        IStateRepository stateRepository,
        ICityRepository cityRepository)
        {
            _addressRepository = addressRepository;
            _deliveryRepository = deliveryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }


        public IList<AddressDTO> GetAll(Pagination pagination)
        {
            return _addressRepository
            .GetAll(pagination)
            .Select(x => new AddressDTO(x))
            .ToList();
        }

        public AddressDTO GetById(int id)
        {
            return new AddressDTO(_addressRepository.GetById(id));
        }

        public int GetTotal()
        {
            return _addressRepository.GetTotal();
        }

        public void Insert(AddressDTO entity)
        {
            _addressRepository.Insert(new Address(entity));
        }

        public void Remove(int id)
        {
            var AddressRemove = _addressRepository.GetById(id);


            _addressRepository.Remove(AddressRemove);


            if (AddressRemove == null)
            {
                throw new NotFoundException($"The address with ID: {AddressRemove.Id} not found.");
            }


            Delivery relation = _deliveryRepository.GetRealtion(id);
            if (relation != null)
            {
                throw new IncorrectInputMessageException($"The address with ID: {id} is related to a delivery.");
            }



        }

        public void Update(AddressDTO entity)
        {
            var AddressInUpdate = _addressRepository.GetById(entity.Id);
            AddressInUpdate.Update(entity);
            _addressRepository.Update(AddressInUpdate);

        }

        public IList<AddressViewModel> GetGeralViewAddress(int? cityId,
                                                            int? stateId,
                                                            string street,
                                                            string cep)
        {
            /*
            var pagination = new Pagination(take, skip);
            var totalRegister = _addressRepository.GetTotal();
            Response.Headers.Add("X-Paginacao-TotalResgistros", totalRegister.ToString());*/

            var query = _addressRepository.GetGeralViewAddress();

            if (cityId.HasValue)
            {
                query = query.Where(a => a.CityId == cityId);
            }
            if (stateId.HasValue)
            {
                query = query.Where(a => a.City.StateId == stateId);
            }

            if (!string.IsNullOrEmpty(street))
            {
                street = street.ToUpper();
                query = query.Where(a => a.Street.Contains(street));
            }

            if (!string.IsNullOrEmpty(cep))
            {
                query = query.Where(a => a.Cep == cep);
            }
          

            List<AddressViewModel> addressesViewModel = new List<AddressViewModel>();
            query.ToList().ForEach(address =>
            {
                addressesViewModel.Add(new AddressViewModel(address));
            });

            return addressesViewModel;

        }

        public AddressViewModel PatchAdressService(AddressDTO address, AddressPatchDTO addressPatchDTO)
        {

            if (address == null)
                throw new NotFoundException($"The address with ID:{address.Id}  not found.");

            string street = addressPatchDTO.Street ?? null;
            string cep = addressPatchDTO.Cep ?? null;
            string complement = addressPatchDTO.Complement ?? null;

            if (street != null)
            {
                if (addressPatchDTO.Street == "")
                    throw new IncorrectInputMessageException("The street name cannot be empty.");
                address.Street = street;
            }

            if (addressPatchDTO.Cep != null)
            {
                if (addressPatchDTO.Cep == "")
                    throw new IncorrectInputMessageException("The cep cannot be empty.");
                if (!addressPatchDTO.Cep.All(char.IsDigit))
                    throw new IncorrectInputMessageException("Every characters in cep must be numeric.");
                address.Cep = cep;
            }

            if (addressPatchDTO.Complement != null)
            {
                if (addressPatchDTO.Complement == "")
                    throw new IncorrectInputMessageException("The complement cannot be empty.");
                address.Complement = complement;
            }

            if (addressPatchDTO.Number != 0)
                address.Number = addressPatchDTO.Number;

            AddressViewModel addressViewModel = new AddressViewModel(address);

            return addressViewModel;




        }

        public void Update(AddressDTO entity, int id)
        {
            throw new NotImplementedException();
        }


        public int PostAdress(int stateId, int cityId, AddressDTO body)
        {
            var idState = _stateRepository.GetById(stateId);
            var idCity = _cityRepository.GetById(cityId);

            if (idState == null || idCity == null)
            {
                throw new NotFoundException($"The State with ID:{stateId} or City with ID:{cityId}   not found.");
            }

            if (idCity.StateId != idState.Id)
            {
                throw new IncorrectInputMessageException("The State Id conflict with City Id.");
            }

            var address = new Address
            {
                CityId = cityId,
                Street = body.Street,
                Number = body.Number,
                Cep = body.Cep,
                Complement = body.Complement,
                City = idCity

            };
            _addressRepository.Insert(address);

            return address.Id;
        }


        public GetCityByIdViewModel GetCityById(int stateId, int cityId)
        {
            var idState = _stateRepository.GetById(stateId);
            var idCity = _cityRepository.GetById(cityId);

            if (idState == null || idCity == null)
            {
                throw new NotFoundException($"The State with ID:{stateId} or City with ID:{cityId}   not found.");
            }

            if (idCity.StateId != idState.Id)
            {
                throw new IncorrectInputMessageException("The State Id conflict with City Id.");
            }

            GetCityByIdViewModel CityById = new GetCityByIdViewModel(
                idCity.Id,
                idCity.Name,
                idState.Id,
                idState.Name,
                idState.Initials
            );
            return CityById;
        }


        public List<GetCityByIdViewModel> GetCityByStateId(int stateId,  string name)

        {
            var state = _stateRepository.GetById(stateId);
            var cityStates = _cityRepository.CitiesInSates(stateId);

            if (state == null)
                throw new NotFoundException($"The State with ID:{stateId}   not found.");


            if (!string.IsNullOrEmpty(name))
            {
                var cityQuery = cityStates.Where(c => c.Name.ToUpper().Contains(name.ToUpper()));

                if (cityQuery.Count() == 0)
                {
                    throw new NotFoundException($"The state not content cities.");
                }

                var queryResponse = cityQuery
                    .Select(c => new GetCityByIdViewModel(
                        c.Id,
                        c.Name,
                        c.State.Id,
                        c.State.Name,
                        c.State.Initials))
                    .ToList();
                return queryResponse;
               

            }


            if (cityStates.Count() == 0)
            {
                throw new NotFoundException($"The State with ID:{stateId}   not found.");
            }


            List<GetCityByIdViewModel> body = new();
            cityStates.ToList().ForEach(
                c =>
                {
                    body.Add(new GetCityByIdViewModel(
                        c.Id,
                        c.Name,
                        c.StateId,
                        c.State.Name,
                        c.State.Initials
                        ));

                }
                );

            return body.ToList();

        }

       
    }
}