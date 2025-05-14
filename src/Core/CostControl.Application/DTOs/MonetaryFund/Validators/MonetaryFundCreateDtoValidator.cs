using FluentValidation;

namespace CostControl.Application.DTOs.MonetaryFund.Validators
{
    public class MonetaryFundCreateDtoValidator : AbstractValidator<MonetaryFundCreateDto>
    {
        public MonetaryFundCreateDtoValidator()
        {
            Include(new MonetaryFundDtoValidator());
        }
    }
}
