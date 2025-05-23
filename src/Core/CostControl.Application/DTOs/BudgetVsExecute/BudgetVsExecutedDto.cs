using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostControl.Application.DTOs.BudgetVsExecute
{
    public class BudgetVsExecutedDto
    {
        public string ExpenseType { get; set; }
        public decimal BudgetedAmount { get; set; }
        public decimal ExecutedAmount { get; set; }
        public string Month { get; set; }
        public int UserId { get; set; }
    }
}
