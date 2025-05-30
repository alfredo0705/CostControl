using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.Budget;
using CostControl.Application.Features.Budget.Requests.Queries;
using MediatR;

namespace CostControl.Application.Features.Budget.Handlers.Queries
{
    public class GetBudgetListRequestHandler : IRequestHandler<GetBudgetListRequest, List<BudgetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBudgetListRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BudgetDto>> Handle(GetBudgetListRequest request, CancellationToken cancellationToken)
        {
            var budgets = await _unitOfWork.BudgetRepository.GetByUserIdAndMonthAsync(request.UserId, request.Period);

            return budgets.ToList();
        }
    }
}
