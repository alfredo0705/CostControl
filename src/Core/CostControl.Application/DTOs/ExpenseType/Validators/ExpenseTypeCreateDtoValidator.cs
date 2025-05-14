using FluentValidation;

namespace CostControl.Application.DTOs.ExpenseType.Validators
{
    public class ExpenseTypeCreateDtoValidator : AbstractValidator<ExpenseTypeCreateDto>
    {
        public ExpenseTypeCreateDtoValidator()
        {
            Include(new ExpenseTypeDtoValidator());
        }
    }
}
