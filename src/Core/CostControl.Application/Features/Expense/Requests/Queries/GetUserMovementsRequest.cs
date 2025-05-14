using CostControl.Application.DTOs.Movement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostControl.Application.Features.Expense.Requests.Queries
{
    public class GetUserMovementsRequest : IRequest<List<MovementDto>>
    {
        public int UserId { get; set; }
        public MovementFilterDto MovementFilterDto { get; set; }
    }
}
