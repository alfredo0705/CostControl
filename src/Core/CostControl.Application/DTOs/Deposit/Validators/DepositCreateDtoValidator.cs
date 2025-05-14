using FluentValidation;

namespace CostControl.Application.DTOs.Deposit.Validators
{
    public class DepositCreateDtoValidator : AbstractValidator<DepositCreateDto>
    {
        public DepositCreateDtoValidator()
        {
            Include(new DepositDtoValidator());
        }
    }
}
