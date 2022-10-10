
using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Entities.Enuns;


namespace DEVinCar.Domain.Entities.Models
{
    public class User
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }


        public string Email { get; set; }
        public string Password {  get; set; }        
        public Permission Permission { get; set; }

        public User()
        {

        }

        public User(UserDTO userDTO)
        {
        
            Name = userDTO.Name;
            Email = userDTO.Email;
            Password = userDTO.Password;
            BirthDate = userDTO.BirthDate;
            Permission = userDTO.Permission;

        }
        public User(LoginDTO LoginDTO)
        {
          
            Email = LoginDTO.Email;
            Password = LoginDTO.Password;
            
           
        }

        public void Update(UserDTO userDTO)
        {
          
            Name = userDTO.Name;
            Email = userDTO.Email;
            Password = userDTO.Password;
            BirthDate = userDTO.BirthDate;
        }
        public User(int v, string email, string password, string name, DateTime birthDate, Permission permission)
        {
            
            Email = email;
            Password = password;
            Name = name;
            BirthDate = birthDate;
            Permission = permission;
        }
    }
}