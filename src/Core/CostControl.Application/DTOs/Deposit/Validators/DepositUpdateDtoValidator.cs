using FluentValidation;

namespace CostControl.Application.DTOs.Deposit.Validators
{
    public class DepositUpdateDtoValidator : AbstractValidator<DepositUpdateDto>
    {
        public DepositUpdateDtoValidator()
        {
            Include(new DepositDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Es obligatorio")
                .GreaterThan(0).WithMessage("Id debe ser mayor que 0");
        }
    }
}
