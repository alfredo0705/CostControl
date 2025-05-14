using CostControl.Application.DTOs.ExpenseType;
using CostControl.Domain.Entity;

namespace CostControl.Application.Contracts.Persistence
{
    public interface IExpenseTypeRepository
    {
        Task<ExpenseTypeDto> GetByIdAsync(int id);
        Task<IEnumerable<ExpenseTypeDto>> GetAllAsync();
        Task AddAsync(ExpenseType expenseTypeDto);
        Task UpdateAsync(ExpenseTypeUpdateDto expenseTypeDto);
        Task DeleteAsync(int id);

        Task<string> GenerateNextExpenseTypeCodeAsync();
    }
}
