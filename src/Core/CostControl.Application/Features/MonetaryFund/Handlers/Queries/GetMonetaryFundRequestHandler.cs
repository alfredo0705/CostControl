using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.MonetaryFund;
using CostControl.Application.Features.MonetaryFund.Requests.Queries;
using MediatR;

namespace CostControl.Application.Features.MonetaryFund.Handlers.Queries
{
    public class GetMonetaryFundRequestHandler : IRequestHandler<GetMonetaryFundRequest, MonetaryFundDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMonetaryFundRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MonetaryFundDto> Handle(GetMonetaryFundRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MonetaryFundRepository.GetByUserIdAndNameAsync(request.MonetaryFoundName);
        }
    }
}
