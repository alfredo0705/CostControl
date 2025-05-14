using CostControl.Application.DTOs.Movement;
using CostControl.Domain.Entity;

namespace CostControl.Application.Contracts.Persistence
{
    public interface IExpenseRepository
    {
        Task CreateExpenseAsync(Expense headerDto);
        Task<IEnumerable<MovementDto>> GetUserMovementsAsync(int userId, MovementFilterDto filter);
    }
}
