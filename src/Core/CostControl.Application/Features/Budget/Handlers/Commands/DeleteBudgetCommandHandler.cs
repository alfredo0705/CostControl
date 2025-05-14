using CostControl.Application.Contracts.Persistence;
using CostControl.Application.Features.Budget.Requests.Commands;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.Budget.Handlers.Commands
{
    public class DeleteBudgetCommandHandler : IRequestHandler<DeleteBudgetCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBudgetCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                await _unitOfWork.BudgetRepository.DeleteAsync(request.Id);
                await _unitOfWork.SaveAsync();

                response.Success = true;
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
