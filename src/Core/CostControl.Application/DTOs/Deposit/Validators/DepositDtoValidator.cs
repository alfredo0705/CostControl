using FluentValidation;

namespace CostControl.Application.DTOs.Deposit.Validators
{
    public class DepositDtoValidator : AbstractValidator<IDepositDto>
    {
        public DepositDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Debe especificar el usuario que realiza el depósito.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Debe especificarse la fecha del depósito.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha del depósito no puede ser en el futuro.");

            RuleFor(x => x.MonetaryFundId)
                .GreaterThan(0).WithMessage("Debe seleccionarse un fondo monetario válido.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("El monto del depósito debe ser mayor a cero.");
        }
    }
}
