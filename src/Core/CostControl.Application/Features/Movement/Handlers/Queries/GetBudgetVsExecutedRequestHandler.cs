using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.BudgetVsExecute;
using CostControl.Application.Features.Movement.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostControl.Application.Features.Movement.Handlers.Queries
{
    public class GetBudgetVsExecutedRequestHandler : IRequestHandler<GetBudgetVsExecutedRequest, List<BudgetVsExecutedDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBudgetVsExecutedRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BudgetVsExecutedDto>> Handle(GetBudgetVsExecutedRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BudgetRepository.GetBudgetVsExecutedAsync(request.UserId, request.BudgetExecutionFilterDto);
        }
    }
}
