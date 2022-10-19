
using DEVinCar.Domain.Entities.DTOs;
using FluentValidation;

namespace DEVinCar.Domain.Validations.FluentValidations
{
    public class CityDTOValidators : AbstractValidator<CityDTO>
    {
        public CityDTOValidators()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The name is required")
                .Length(3 , 50).WithMessage("The City must have a maximum of 50 characters");
        }
    }
}