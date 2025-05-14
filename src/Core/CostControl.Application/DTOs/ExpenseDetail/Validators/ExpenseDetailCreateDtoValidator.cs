using FluentValidation;

namespace CostControl.Application.DTOs.ExpenseDetail.Validators
{
    public class ExpenseDetailCreateDtoValidator : AbstractValidator<ExpenseDetailCreateDto>
    {
        public ExpenseDetailCreateDtoValidator()
        {
            Include(new ExpenseDetailDtoValidator());
        }
    }
}
