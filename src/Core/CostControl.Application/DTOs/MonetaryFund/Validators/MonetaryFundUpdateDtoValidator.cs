using FluentValidation;

namespace CostControl.Application.DTOs.MonetaryFund.Validators
{
    public class MonetaryFundUpdateDtoValidator : AbstractValidator<MonetaryFundUpdateDto>
    {
        public MonetaryFundUpdateDtoValidator()
        {
            Include(new MonetaryFundDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Es obligatorio")
                .GreaterThan(0).WithMessage("Id debe ser mayor que 0");
        }
    }
}
