using FluentValidation;

namespace CostControl.Application.DTOs.Expense.Validators
{
    public class ExpenseCreateDtoValidator : AbstractValidator<ExpenseCreateDto>
    {
        public ExpenseCreateDtoValidator()
        {
            Include(new ExpenseDtoValidator());

            RuleFor(x => x.Details).NotEmpty();
        }
    }
}
