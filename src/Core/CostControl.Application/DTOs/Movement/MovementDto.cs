using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostControl.Application.DTOs.Movement
{
    public class MovementDto
    {
        public string UserName { get; set; }
        public string MovementType { get; set; } // "Gasto" o "Depósito"
        public DateTime Date { get; set; }
        public string FundName { get; set; }
        public decimal Amount { get; set; }

        // Si es Gasto:
        public string? ExpenseType { get; set; }
        public string? StoreName { get; set; }
        public string? DocumentType { get; set; }

        // Si es Depósito: solo usas los campos básicos
    }
}
