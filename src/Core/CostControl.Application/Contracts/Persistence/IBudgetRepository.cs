using CostControl.Application.DTOs.Budget;
using CostControl.Application.DTOs.BudgetVsExecute;
using CostControl.Application.DTOs.Movement;
using CostControl.Domain.Entity;

namespace CostControl.Application.Contracts.Persistence
{
    public interface IBudgetRepository
    {
        Task<BudgetDto?> GetByIdAsync(int id);
        Task<IEnumerable<BudgetDto>> GetByUserIdAndMonthAsync(int userId, DateTime period);
        Task<BudgetDto> GetByUserIdTypeAndMonthAsync(int userId, int expenseTypeId, DateTime period);
        Task AddAsync(Budget budget);
        Task UpdateAsync(BudgetUpdateDto budget);
        Task DeleteAsync(int id);
        Task<List<BudgetVsExecutedDto>> GetBudgetVsExecutedAsync(int userId, BudgetExecutionFilterDto filter);
        Task<List<MovementDto>> GetMovementsAsync(int userId, MovementFilterDto filter);
        Task<bool> GetByExpenseTypeAsync(int expenseTypeId);
    }
}
