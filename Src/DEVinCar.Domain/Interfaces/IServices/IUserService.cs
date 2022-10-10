using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Interfaces.IBases;

namespace DEVinCar.Domain.Interfaces.IServices
{
    public interface IUserService : IBaseService<UserDTO, int>
    {
        public User GetUserById(int id);
        public User GetUserByDTO(UserDTO entity);
        public User GetUserPassword(LoginDTO entity);
        public List<User> GetQueriableUser(string Name, DateTime? birthDateMax, DateTime? birthDateMin);
       
    }
}