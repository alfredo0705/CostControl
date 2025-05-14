using CostControl.Application.Contracts.Persistence;
using CostControl.Application.Features.ExpenseType.Requests.Commands;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.ExpenseType.Handlers.Commands
{
    public class DeleteExpenseTypeCommandHandler : IRequestHandler<DeleteExpenseTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExpenseTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(DeleteExpenseTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                await _unitOfWork.ExpenseTypeRepository.DeleteAsync(request.Id);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Message = "Eliminado exitosamente";
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
