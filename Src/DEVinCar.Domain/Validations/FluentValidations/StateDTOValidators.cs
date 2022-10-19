
using System.Data;
using DEVinCar.Domain.Entities.DTOs;
using FluentValidation;

namespace DEVinCar.Domain.Validations.FluentValidations
{
    public class StateDTOValidators : AbstractValidator<StateDTO>
    {
        public StateDTOValidators()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Enter a name of state")
                .Length(2,100).WithMessage("State name must be a maximum of 100 characters.");

            RuleFor(x => x.Initials)
                .NotEmpty().WithMessage("The initiais is required.")
                .Length(2,2).WithMessage("State initials must be a maximum of 2 characters.");
            
        }
    }
}