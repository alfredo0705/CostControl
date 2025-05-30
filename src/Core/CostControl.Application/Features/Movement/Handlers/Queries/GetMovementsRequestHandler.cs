using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.Movement;
using CostControl.Application.Features.Movement.Requests.Queries;
using MediatR;

namespace CostControl.Application.Features.Movement.Handlers.Queries
{
    public class GetMovementsRequestHandler : IRequestHandler<GetMovementsRequest, List<MovementDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMovementsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MovementDto>> Handle(GetMovementsRequest request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BudgetRepository.GetMovementsAsync(request.UserId, request.BudgetExecutionFilterDto);
        }
    }
}
