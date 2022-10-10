using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Interfaces.IServices;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Validations.Exceptions;

namespace DEVinCar.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository =  userRepository;
        }
        public IList<UserDTO> GetAll(Pagination pagination)
        {
            return _userRepository
          .GetAll(pagination)
          .Select(x => new UserDTO(x))
          .ToList();
        }

        public UserDTO GetById(int id)
        {
            return new UserDTO(_userRepository.GetById(id));
        }
        public User GetUserById(int id)
        {
         
            return _userRepository.GetById(id);
            
        }

        public User GetUserByDTO(UserDTO entity)
        {

            var newUser = _userRepository.GetUserName(entity);

            if (newUser != null)
            {
                throw new IncorrectInputMessageException($"The input incorrect.");
            }
            Insert(entity);

            return newUser;
        }

        public int GetTotal()
        {
            return _userRepository.GetTotal();
        }

        public void Insert(UserDTO entity)
        {
           
            _userRepository.Insert(new User(entity));
        }

        

        public void Remove(int id)
        {
            var UserRemove = _userRepository.GetById(id);
            if (UserRemove == null)
            {
                throw new IncorrectInputMessageException($"The input Id incorrect or not exists.");
            }
            _userRepository.Remove(UserRemove);
        }

        public void Update(UserDTO entity, int id)
        {
            var UserUpdate = _userRepository.GetUserName(entity);
            UserUpdate.Update(entity);
            _userRepository.Update(UserUpdate);
        }
        public User GetUserPassword(LoginDTO entity){


            return _userRepository.GetUserPassword(entity);
        }

        public List<User> GetQueriableUser( string Name, DateTime? birthDateMax, DateTime? birthDateMin)
        {
            var query = _userRepository.GetGeralViewUser();

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(c => c.Name.Contains(Name));
            }

            if (birthDateMin.HasValue)
            {
                query = query.Where(c => c.BirthDate >= birthDateMin.Value);
            }

            if (birthDateMax.HasValue)
            {
                query = query.Where(c => c.BirthDate <= birthDateMax.Value);
            }

            if (!query.ToList().Any())
            {
                throw new IncorrectInputMessageException($"The input incorrect.");
            }

            return query.ToList();
        }

      
    }
}