
using DEVinCar.Domain.Entities.Models;
using FluentValidation;

namespace DEVinCar.Domain.Validations.FluentValidations
{
    public class CarValidations : AbstractValidator<Car>
    {
        public CarValidations()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please enter a name car !");
                
        }
    }
}