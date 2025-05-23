using FluentValidation;

namespace CostControl.Application.DTOs.Budget.Validator
{
    public class BudgetDtoValidator : AbstractValidator<IBudgetDto>
    {
        public BudgetDtoValidator()
        {
            RuleFor(x => x.ExpenseTypeId)
                .GreaterThan(0).WithMessage("Debe seleccionarse un tipo de gasto válido.");

            RuleFor(x => x.Month)
                .NotEmpty().WithMessage("Debe especificar un mes.");

            RuleFor(x => x.Year)
                .NotEmpty().WithMessage("Debe especificar un año.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("El monto presupuestado debe ser mayor a cero.");
        }
    }
}
