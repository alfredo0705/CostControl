using FluentValidation;

namespace CostControl.Application.DTOs.Expense.Validators
{
    public class ExpenseUpdateDtoValidator : AbstractValidator<ExpenseUpdateDto>
    {
        public ExpenseUpdateDtoValidator()
        {
            Include(new ExpenseDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Es obligatorio")
                .GreaterThan(0).WithMessage("Id debe ser mayor que 0");
        }
    }
}
