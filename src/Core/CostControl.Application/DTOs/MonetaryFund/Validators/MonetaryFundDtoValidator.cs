using FluentValidation;

namespace CostControl.Application.DTOs.MonetaryFund.Validators
{
    public class MonetaryFundDtoValidator : AbstractValidator<IMonetaryFundDto>
    {
        public MonetaryFundDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El nombre del fondo es obligatorio.")
                .MinimumLength(4)
                .MaximumLength(50);

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("El tipo de fondo es obligatorio.")
                .Must(type => type == "Efectivo" || type == "Cuenta Bancaria")
                .WithMessage("El tipo de fondo debe ser 'Efectivo' o 'Cuenta Bancaria'.");

            RuleFor(x => x.InitialBalance)
                .GreaterThanOrEqualTo(0).WithMessage("El saldo inicial no puede ser negativo.");
        }
    }
}
