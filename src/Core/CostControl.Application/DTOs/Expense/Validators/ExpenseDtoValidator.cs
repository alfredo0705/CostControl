using FluentValidation;

namespace CostControl.Application.DTOs.Expense.Validators
{
    public class ExpenseDtoValidator : AbstractValidator<IExpenseDto>
    {
        public ExpenseDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Debe especificarse el usuario.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Debe especificarse la fecha del gasto.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha del gasto no puede ser futura.");

            RuleFor(x => x.MonetaryFundId)
                .GreaterThan(0).WithMessage("Debe seleccionarse un fondo monetario válido.");

            RuleFor(x => x.StoreName)
                .NotEmpty().WithMessage("Debe ingresar el nombre del comercio.")
                .MaximumLength(100).WithMessage("El nombre del comercio no puede superar los 100 caracteres.");

            RuleFor(x => x.DocumentType)
                .NotEmpty().WithMessage("Debe especificar el tipo de documento.")
                .Must(type => new[] { "Factura", "Comprobante", "Otro" }.Contains(type))
                .WithMessage("Tipo de documento inválido. Debe ser Factura, Comprobante o Otro.");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Las observaciones no pueden superar los 500 caracteres.");
        }
    }

}
