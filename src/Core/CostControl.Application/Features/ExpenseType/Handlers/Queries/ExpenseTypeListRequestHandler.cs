using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.ExpenseType;
using CostControl.Application.Features.ExpenseType.Requests.Queries;
using MediatR;

namespace CostControl.Application.Features.ExpenseType.Handlers.Queries
{
    public class ExpenseTypeListRequestHandler : IRequestHandler<ExpenseTypeListRequest, List<ExpenseTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpenseTypeListRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ExpenseTypeDto>> Handle(ExpenseTypeListRequest request, CancellationToken cancellationToken)
        {
            var types = await _unitOfWork.ExpenseTypeRepository.GetAllAsync();
            return types.ToList();
        }
    }
}
