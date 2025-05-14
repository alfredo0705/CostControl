using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.Budget;
using CostControl.Application.Features.Budget.Requests.Queries;
using MediatR;

namespace CostControl.Application.Features.Budget.Handlers.Queries
{
    public class GetBudgetRequestHandler : IRequestHandler<GetBudgetRequest, BudgetDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBudgetRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BudgetDto> Handle(GetBudgetRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BudgetRepository.GetByIdAsync(request.Id);
        }
    }
}
