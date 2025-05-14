using FluentValidation;

namespace CostControl.Application.DTOs.Budget.Validator
{
    public class BudgetCreateDtoValidator : AbstractValidator<BudgetCreateDto>
    {
        public BudgetCreateDtoValidator()
        {
            Include(new BudgetDtoValidator());
        }
    }
}