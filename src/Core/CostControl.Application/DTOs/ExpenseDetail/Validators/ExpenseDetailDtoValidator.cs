using FluentValidation;

namespace CostControl.Application.DTOs.ExpenseDetail.Validators
{
    public class ExpenseDetailDtoValidator : AbstractValidator<IExpenseDetailDto>
    {
        public ExpenseDetailDtoValidator()
        {
            RuleFor(x => x.ExpenseId)
                .GreaterThan(0).WithMessage("Debe asociarse a un gasto válido.");

            RuleFor(x => x.ExpenseTypeId)
                .GreaterThan(0).WithMessage("Debe seleccionarse un tipo de gasto válido.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("El monto debe ser mayor a 0.");
        }
    }
}
