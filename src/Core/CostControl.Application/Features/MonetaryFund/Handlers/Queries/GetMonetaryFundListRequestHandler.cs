using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.MonetaryFund;
using CostControl.Application.Features.MonetaryFund.Requests.Queries;
using MediatR;

namespace CostControl.Application.Features.MonetaryFund.Handlers.Queries
{
    public class GetMonetaryFundListRequestHandler : IRequestHandler<GetMonetaryFundListRequest, List<MonetaryFundDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMonetaryFundListRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MonetaryFundDto>> Handle(GetMonetaryFundListRequest request, CancellationToken cancellationToken)
        {
            var monetaryFunds = await _unitOfWork.MonetaryFundRepository.GetFundsByUserIdAsync(request.UserId);

            return monetaryFunds.ToList();
        }
    }
}
