using System.Data;
using DEVinCar.Domain.Entities.DTOs;
using FluentValidation;

namespace DEVinCar.Domain.Validations.FluentValidations
{
    public class UserDTOValidators : AbstractValidator<UserDTO>
    {
        public UserDTOValidators()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("The Password is required")
                .Length(4, 10).WithMessage("the  Password min 4 and must be a maximum of 10 characters !")
                .Must(CheckValuePassword).WithMessage("Invalid Password.")
                .Matches(@"^(.{0,7}|[^0-9]*|[^A-Z])$");
            RuleFor(x => x.Email)
                .NotNull()
                .Length(3, 100).WithMessage("the Email must be a maximum of 100 characters !")
                .EmailAddress().WithMessage("Format input email not accept !"); 

             RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Enter BirthDate!")               
                .Must(CheckBirthDate).WithMessage("the user must be of legal age !")
                .Must(ValidDate).WithMessage("Incorect Format BirthDate!"); 

            
                
                

                
            
        }

        private static bool CheckBirthDate(System.DateTime birthDate )
        {
            return birthDate <= System.DateTime.Now.AddYears(-18);
        }

        private static bool CheckValuePassword(object value)
        {
            string password = value.ToString();
            var arrPassword = password.ToCharArray().ToList();

            foreach (char letter in arrPassword)
            {
                if (letter != arrPassword[0])
                    return true;
            }
            return false;

        }

        private static bool ValidDate(DateTime val)
        {
            DateTime date;
            
            return DateTime.TryParse(val.ToString(), out date);
        }
        
    }
}