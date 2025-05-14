using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.Budget.Validator;
using CostControl.Application.Features.Budget.Requests.Commands;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.Budget.Handlers.Commands
{
    public class UpdateBudgetCommandHandler : IRequestHandler<UpdateBudgetCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBudgetCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(UpdateBudgetCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                var validator = new BudgetUpdateDtoValidator();
                var validationResult = validator.Validate(request.BudgetUpdateDto);
                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Actualizacion fallida";

                    return response;
                }

                await _unitOfWork.BudgetRepository.UpdateAsync(request.BudgetUpdateDto);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Message = "Actualizacion exitosa";
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
