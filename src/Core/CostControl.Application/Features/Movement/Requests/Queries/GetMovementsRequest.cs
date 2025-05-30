using CostControl.Application.DTOs.BudgetVsExecute;
using CostControl.Application.DTOs.Movement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostControl.Application.Features.Movement.Requests.Queries
{
    public class GetMovementsRequest : IRequest<List<MovementDto>>
    {
        public int UserId { get; set; }
        public MovementFilterDto BudgetExecutionFilterDto { get; set; }
    }
}
