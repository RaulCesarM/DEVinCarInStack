
using DEVinCar.Domain.Entities.Models;
using FluentValidation;

namespace DEVinCar.Domain.Validations.FluentValidations
{
    public class CarValidators : AbstractValidator<Car>
    {
        public CarValidators()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name is required")
            .Length(3, 50).WithMessage("Car name must be a maximum of 50 characters");
                
        }
    }
}