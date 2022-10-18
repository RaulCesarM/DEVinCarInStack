

using DEVinCar.Domain.Entities.DTOs;
using DEVinCar.Domain.Validations.FluentValidations;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace DEVinCar.Test
{
    [TestFixture]
    public class UserTestNunit
    {

        private  UserDTOValidators validator;
        [SetUp]
        public void Setup()
        {
            validator = new UserDTOValidators();
        }

        [TestCase("Rraulzito737@gmail.com")]
        public void Validate_Email_in_userDto_Acept(string email)
        {           
          var Person = new UserDTO{ Email = email , Name = "RAUL",Password ="asd45uidfgdfgo"};
            var result = validator.TestValidate(Person);
            result.ShouldNotHaveValidationErrorFor(person => person.Email);
        }


        [TestCase("Rraulzito737333333gmail.com")]
        public void Validate_Email_in_userDto_Not_Acept(string email) {

            var Person = new UserDTO { Email = email, Name = "RAUL", Password = "asd45uidfgdfgo" };
            var result = validator.TestValidate(Person);
            result.ShouldHaveValidationErrorFor(person => person.Email);

        }

    }
}