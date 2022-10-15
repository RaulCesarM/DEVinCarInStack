using DEVinCar.Domain.Entities.Models;
using FluentValidation;

namespace DEVinCar.Domain.Validations.FluentValidations
{
    public class AddressValidators : AbstractValidator<Address>
    {

        public AddressValidators()
        {
            RuleFor(x => x.Street)
                  .NotEmpty().WithMessage("Please enter a street !")
                 .Length(3, 100).WithMessage("Street name must be a maximum of 100 characters");

            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("Please enter a CEP !")
                .Length(1, 8).WithMessage("The CEP must have a maximum of 8 characters");

            RuleFor(x => x.Complement)
               .NotEmpty().WithMessage("Please enter a Complement !")
               .Length(1, 8).WithMessage("The Complement must have a maximum of 255 characters");

            
        }
        
    }
}