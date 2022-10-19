
using DEVinCar.Domain.Entities.DTOs;
using FluentValidation;

namespace DEVinCar.Domain.Validations.FluentValidations
{
    public class BuyDTOValidators: AbstractValidator<BuyDTO>
    {
        public BuyDTOValidators()
        {
            RuleFor(x => x.SellerId)
                .NotEmpty().WithMessage("The SelleId is required.");
        }
    }
}