using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.Movement;
using CostControl.Application.Features.Expense.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostControl.Application.Features.Expense.Handlers.Queries
{
    public class GetUserMovementsRequestHandler : IRequestHandler<GetUserMovementsRequest, List<MovementDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserMovementsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MovementDto>> Handle(GetUserMovementsRequest request, CancellationToken cancellationToken)
        {
            var movements = await _unitOfWork.ExpenseRepository.GetUserMovementsAsync(request.UserId, request.MovementFilterDto);

            return movements.ToList();
        }
    }
}
