using System.ComponentModel.DataAnnotations;
using DEVinCar.Domain.Entities.Enuns;
using DEVinCar.Domain.Entities.Models;
using DEVinCar.Domain.Util;

namespace DEVinCar.Domain.Entities.DTOs
{
    public class UserDTO{
       
        public int Id { get; set; }      
        public string Name { get; set; }
        public string Email { get; set; }       
        public string Password { get; set; }
     //   [DataType(DataType.Date, ErrorMessage="Date must be valid")]
      //  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
       
        public DateTime BirthDate { get; set; }
        public Permission Permission { get; set; }

        public UserDTO()
        {

        }

        public UserDTO(User user)
        {
          
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            BirthDate = user.BirthDate;
            Permission = user.Permission;
            

        }
      
    }
}