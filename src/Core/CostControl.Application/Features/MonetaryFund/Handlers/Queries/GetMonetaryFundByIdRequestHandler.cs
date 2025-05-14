using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.MonetaryFund;
using CostControl.Application.Features.MonetaryFund.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostControl.Application.Features.MonetaryFund.Handlers.Queries
{
    public class GetMonetaryFundByIdRequestHandler : IRequestHandler<GetMonetaryFundByIdRequest, MonetaryFundDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMonetaryFundByIdRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MonetaryFundDto> Handle(GetMonetaryFundByIdRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MonetaryFundRepository.GetByIdAsync(request.Id);
        }
    }
}
