using Microsoft.EntityFrameworkCore.Storage;

namespace CostControl.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IExpenseTypeRepository ExpenseTypeRepository { get; }
        IMonetaryFundRepository MonetaryFundRepository { get; }
        IBudgetRepository BudgetRepository { get; }
        IExpenseRepository ExpenseRepository { get; }
        IExpenseDetailsRepository ExpenseDetailsRepository { get; }
        IDepositRepository DepositRepository { get; }

        IExecutionStrategy CreateExecutionStrategy();
        Task SaveAsync();
        bool HasChanges();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
