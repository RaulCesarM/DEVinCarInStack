using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Validations.Exceptions;
using DEVinCar.Domain.Entities.ViewModels;

namespace DEVinCar.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        public StateService(IStateRepository stateRepository, ICityRepository _cityRepository)
        {
            _stateRepository = stateRepository;
            this._cityRepository =  _cityRepository;
        }
        public IList<StateDTO> GetAll(Pagination pagination)
        {
            return _stateRepository
           .GetAll(pagination)
           .Select(x => new StateDTO(x))
           .ToList();
        }

        public StateDTO GetById(int id)
        {

           var state = new StateDTO(_stateRepository.GetById(id));
            if (state == null)
            {
                throw new NotFoundException("State id not found or not exists !"); 
            }
            return state;
           



            
        }

        public int GetTotal()
        {
            return _stateRepository.GetTotal();
        }

        public void Insert(StateDTO entity)
        {
            _stateRepository.Insert(new State(entity));
        }

        public void Remove(int id)
        {
            var StateRemove = _stateRepository.GetById(id);
            _stateRepository.Remove(StateRemove);
        }

        public void Update(StateDTO entity, int id)
        {
            var StateUpdate = _stateRepository.GetById(entity.Id);
            StateUpdate.Update(entity);
            _stateRepository.Update(StateUpdate);
        }

        public int PostCity( int stateId,  CityDTO cityDTO)
        {


            var state = _stateRepository.GetById(stateId);

            if (state == null)
            {
                throw new IncorrectInputMessageException($"The input incorrect.");
            }


            if (_cityRepository.Checked(stateId,cityDTO ))
            {
                throw new IncorrectInputMessageException($"The input value not match");
            }
           
            var city = new City
            {
                Name = cityDTO.Name,
                StateId = stateId,
            };

            _cityRepository.Insert(city);

            return  city.Id;
        }

        public List<GetStateViewModel> GetStateByName( string name)
        {
            var query = _stateRepository.GetGeralViewState();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.Name.ToUpper().Contains(name.ToUpper()));
            }
            if (query.Any())
            {
                List<GetStateViewModel> getStateViewModels = new List<GetStateViewModel>();
                query.ToList().ForEach(state =>
                    {
                        GetStateViewModel getState = new GetStateViewModel(state.Id, state.Name, state.Initials);
                        state.Cities.ForEach(city =>
                        {
                            getState.Cities.Add(city.Name);
                        });
                        getStateViewModels.Add(getState);
                    });
                return getStateViewModels;
            }

            throw new NotFoundException("State name not found or not exists !");
        }

        



        }
}