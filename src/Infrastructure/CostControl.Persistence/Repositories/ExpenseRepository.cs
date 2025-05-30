using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.Movement;
using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CostControl.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly CostControlDbContext _context;

        public ExpenseRepository(CostControlDbContext context)
        {
            _context = context;
        }

        public async Task CreateExpenseAsync(Expense headerDto)
        {
            await _context.Expenses.AddAsync(headerDto);
        }

        public async Task<bool> ExpenseByMonetaryFundExist(int monetariFundId)
        {
            return await _context.Expenses.AnyAsync(e => e.MonetaryFundId == monetariFundId);
        }
    }
}
