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
