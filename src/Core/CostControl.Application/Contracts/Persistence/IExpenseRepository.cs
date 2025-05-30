using CostControl.Application.DTOs.Movement;
using CostControl.Domain.Entity;

namespace CostControl.Application.Contracts.Persistence
{
    public interface IExpenseRepository
    {
        Task CreateExpenseAsync(Expense headerDto);
        Task<bool> ExpenseByMonetaryFundExist(int monetariFundId);
    }
}
