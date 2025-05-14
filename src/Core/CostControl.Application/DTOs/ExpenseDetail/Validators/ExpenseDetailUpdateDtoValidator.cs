using FluentValidation;

namespace CostControl.Application.DTOs.ExpenseDetail.Validators
{
    public class ExpenseDetailUpdateDtoValidator : AbstractValidator<ExpenseDetailUpdateDto>
    {
        public ExpenseDetailUpdateDtoValidator()
        {
            Include(new ExpenseDetailDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Es obligatorio")
                .GreaterThan(0).WithMessage("Id debe ser mayor que 0");
        }
    }
}
