
using DEVinCar.Domain.Entities.DTOs;
using FluentValidation;

namespace DEVinCar.Domain.Validations.FluentValidations
{
    public class SaleDTOValiadtors : AbstractValidator<SaleDTO>
    {
        public SaleDTOValiadtors()
        {
            RuleFor(x => x.BuyerId)
                .NotEmpty().WithMessage("Please enter a Bayer id");
        }
    }
}