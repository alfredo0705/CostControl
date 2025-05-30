using CostControl.Application.DTOs.BudgetVsExecute;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostControl.Application.Features.Movement.Requests.Queries
{
    public class GetBudgetVsExecutedRequest : IRequest<List<BudgetVsExecutedDto>>
    {
        public int UserId { get; set; }
        public BudgetExecutionFilterDto BudgetExecutionFilterDto { get; set; }
    }
}
