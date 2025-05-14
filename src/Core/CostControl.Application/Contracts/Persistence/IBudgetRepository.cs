using CostControl.Application.DTOs.Budget;
using CostControl.Application.DTOs.BudgetVsExecute;
using CostControl.Domain.Entity;

namespace CostControl.Application.Contracts.Persistence
{
    public interface IBudgetRepository
    {
        Task<BudgetDto?> GetByIdAsync(int id);
        Task<IEnumerable<BudgetDto>> GetByUserIdAndMonthAsync(int userId, int year, int month);
        Task<BudgetDto> GetByUserIdTypeAndMonthAsync(int userId, int expenseTypeId, int year, int month);
        Task AddAsync(Budget budget);
        Task UpdateAsync(BudgetUpdateDto budget);
        Task DeleteAsync(int id);
        Task<List<BudgetVsExecutedDto>> GetBudgetVsExecutedAsync(int userId, BudgetExecutionFilterDto filter);
    }
}
