using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.ExpenseType;
using CostControl.Application.Features.ExpenseType.Requests.Queries;
using MediatR;

namespace CostControl.Application.Features.ExpenseType.Handlers.Queries
{
    public class ExpenseTypeRequestHandler : IRequestHandler<ExpenseTypeRequest, ExpenseTypeDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpenseTypeRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ExpenseTypeDto> Handle(ExpenseTypeRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ExpenseTypeRepository.GetByIdAsync(request.Id);
        }
    }
}
