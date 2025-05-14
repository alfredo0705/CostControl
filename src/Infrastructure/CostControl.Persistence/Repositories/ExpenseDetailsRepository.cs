using CostControl.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CostControl.Persistence.Repositories
{
    public class ExpenseDetailsRepository : IExpenseDetailsRepository
    {
        private readonly CostControlDbContext _context;

        public ExpenseDetailsRepository(CostControlDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> SpentSoFar(int expenseTypeId, int userId, int year, int month)
        {
            return await _context.ExpenseDetails
                        .Where(d => d.ExpenseTypeId == expenseTypeId &&
                                    d.Expense.UserId == userId &&
                                    d.Expense.Date.Year == year &&
                                    d.Expense.Date.Month == month)
                        .SumAsync(d => d.Amount);
        }
    }
}
