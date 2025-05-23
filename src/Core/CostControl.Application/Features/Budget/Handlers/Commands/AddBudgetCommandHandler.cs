using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.Budget.Validator;
using CostControl.Application.Features.Budget.Requests.Commands;
using CostControl.Application.Responses;
using FluentValidation;
using MediatR;
using System.Linq;

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
                foreach (var item in request.BudgetCreateDto)
                {
                    var validator = new BudgetCreateDtoValidator();
                    var validationResult = validator.Validate(item);
                    if (!validationResult.IsValid)
                    {
                        response.Success = false;
                        response.Message = "Creación fallida";

                        return response;
                    }

                    var budget = new Domain.Entity.Budget
                    {
                        Amount = item.Amount,
                        AppUserId = request.UserId,
                        ExpenseTypeId = item.ExpenseTypeId,
                        Month = item.Month,
                        Year = item.Year
                    };

                    await _unitOfWork.BudgetRepository.AddAsync(budget);

                }

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
