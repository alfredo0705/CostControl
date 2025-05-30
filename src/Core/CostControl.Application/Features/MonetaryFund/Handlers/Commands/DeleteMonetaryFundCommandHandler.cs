using CostControl.Application.Contracts.Persistence;
using CostControl.Application.Features.MonetaryFund.Requests.Commands;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.MonetaryFund.Handlers.Commands
{
    public class DeleteMonetaryFundCommandHandler : IRequestHandler<DeleteMonetaryFundCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMonetaryFundCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(DeleteMonetaryFundCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                if (await _unitOfWork.DepositRepository.DepositByMonetaryFundExists(request.Id) || 
                    await _unitOfWork.ExpenseRepository.ExpenseByMonetaryFundExist(request.Id))
                {
                    response.Success = false;
                    response.Message = "No se puede eliminar este fondo monetario porque está vinculado a uno o más Depósitos o Gastos.";
                    return response;
                }

                await _unitOfWork.MonetaryFundRepository.DeleteAsync(request.Id);
                await _unitOfWork.SaveAsync();
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
