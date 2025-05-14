using FluentValidation;

namespace CostControl.Application.DTOs.ExpenseType.Validators
{
    public class ExpenseTypeDtoValidator : AbstractValidator<IExpenseTypeDto>
    {
        public ExpenseTypeDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es requerida.")
                .MaximumLength(250).WithMessage("La descripción no puede exceder los 250 caracteres.");
        }
    }

}
