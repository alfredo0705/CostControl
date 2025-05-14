using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostControl.Application.DTOs.BudgetVsExecute
{
    public class BudgetExecutionFilterDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
