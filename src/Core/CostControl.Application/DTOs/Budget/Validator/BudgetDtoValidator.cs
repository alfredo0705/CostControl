using FluentValidation;

namespace CostControl.Application.DTOs.Budget.Validator
{
    public class BudgetDtoValidator : AbstractValidator<IBudgetDto>
    {
        public BudgetDtoValidator()
        {
            RuleFor(x => x.ExpenseTypeId)
                .GreaterThan(0).WithMessage("Debe seleccionarse un tipo de gasto válido.");

            RuleFor(x => x.Period)
                .NotEmpty().WithMessage("Debe especificar una fecha.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("El monto presupuestado debe ser mayor a cero.");
        }
    }
}
