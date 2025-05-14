using FluentValidation;

namespace CostControl.Application.DTOs.ExpenseType.Validators
{
    public class ExpenseTypeUpdateDtoValidator : AbstractValidator<ExpenseTypeUpdateDto>
    {
        public ExpenseTypeUpdateDtoValidator()
        {
            Include(new ExpenseTypeDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Es obligatorio")
                .GreaterThan(0).WithMessage("Id debe ser mayor que 0");
        }
    }
}
