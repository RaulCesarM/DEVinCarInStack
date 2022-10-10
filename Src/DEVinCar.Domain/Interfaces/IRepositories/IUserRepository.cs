
using DEVinCar.Domain.Interfaces.IBases;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Entities.DTOs;

namespace DEVinCar.Domain.Interfaces.IRepositories
{
    public interface IUserRepository : IBaseRepository<User, int>
    {

        public User GetUserPassword(LoginDTO entity);
        public IQueryable<User> GetGeralViewUser();
        public User GetUserName(UserDTO entity);  
    }
}