using CostControl.Application.DTOs.MonetaryFund;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostControl.Application.Features.MonetaryFund.Requests.Queries
{
    public class GetMonetaryFundByIdRequest : IRequest<MonetaryFundDto>
    {
        public int Id { get; set; }
    }
}
