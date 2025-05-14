using FluentValidation;

namespace CostControl.Application.DTOs.Budget.Validator
{
    public class BudgetUpdateDtoValidator : AbstractValidator<BudgetUpdateDto>
    {
        public BudgetUpdateDtoValidator()
        {
            Include(new BudgetDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Es obligatorio")
                .GreaterThan(0).WithMessage("Id debe ser mayor que 0");
        }
    }
}
