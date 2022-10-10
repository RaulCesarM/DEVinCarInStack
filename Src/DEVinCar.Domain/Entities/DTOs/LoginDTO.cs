
using DEVinCar.Domain.Entities.Models;

namespace DEVinCar.Domain.Entities.DTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginDTO()
        {
            
        }
        public LoginDTO(User user)
        {
           Email = user.Email;
            Password = user.Password;
        }
        public LoginDTO(UserDTO user)
        {
            Email = user.Email;
            Password = user.Password;
        }


    }
}