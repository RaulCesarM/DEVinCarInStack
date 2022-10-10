using DEVinCar.Domain.Interfaces.IRepositories;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Infra.Data.Context;
using DEVinCar.Domain.Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Infra.Data.Repository
{
    public class UserRepository : BaseGenericCrudRepository<User, int>, IUserRepository
    {
        private readonly DevInCarDbContext _context;
        public UserRepository(DevInCarDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetTotal()
        {
            return _context.Users.Count();
        }

        public User GetUserPassword(LoginDTO entity){

            var user = _context.Users.FirstOrDefault(x => x.Email == entity.Email && x.Password == entity.Password);

            return user;

        }

            public IQueryable<User> GetGeralViewUser()
            {
            return _context.Set<User>().AsQueryable();
            }

        public User GetUserName(UserDTO entity)
        {

            var user = _context.Users.FirstOrDefault(x => x.Name == entity.Name);

            return user;

        }
    }
}