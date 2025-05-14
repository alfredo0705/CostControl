using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.Budget.Validator;
using CostControl.Application.Features.Budget.Requests.Commands;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.Budget.Handlers.Commands
{
    public class AddBudgetCommandHandler : IRequestHandler<AddBudgetCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBudgetCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(AddBudgetCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                var validator = new BudgetCreateDtoValidator();
                var validationResult = validator.Validate(request.BudgetCreateDto);
                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Creación fallida";

                    return response;
                }

                var budget = new Domain.Entity.Budget
                {
                    Amount = request.BudgetCreateDto.Amount,
                    AppUserId = request.BudgetCreateDto.AppUserId,
                    ExpenseTypeId = request.BudgetCreateDto.ExpenseTypeId,
                    Month = request.BudgetCreateDto.Month,
                    Year = request.BudgetCreateDto.Year
                };

                await _unitOfWork.BudgetRepository.AddAsync(budget);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Message = "Creación exitosa";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
