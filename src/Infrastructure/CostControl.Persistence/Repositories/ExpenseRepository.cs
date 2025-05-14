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

        public async Task<IEnumerable<MovementDto>> GetUserMovementsAsync(int userId, MovementFilterDto filter)
        {
            var expenses = await _context.Expenses
                .Where(e => e.Date >= filter.From && e.Date <= filter.To)
                .Include(e => e.MonetaryFund)
                .Include(e => e.Details)
                    .ThenInclude(d => d.ExpenseType)
                .SelectMany(e => e.Details.Select(d => new MovementDto
                {
                    UserName = "",
                    MovementType = "Gasto",
                    Date = e.Date,
                    FundName = e.MonetaryFund.Name.Value,
                    Amount = d.Amount,
                    ExpenseType = d.ExpenseType.Name.Value,
                    DocumentType = e.DocumentType,
                    StoreName = e.StoreName
                }))
                .ToListAsync();

            var deposits = await _context.Deposits
                .Where(d => d.Date >= filter.From && d.Date <= filter.To)
                .Include(d => d.MonetaryFund)
                .Select(d => new MovementDto
                {
                    UserName = "",
                    MovementType = "Depósito",
                    Date = d.Date,
                    FundName = d.MonetaryFund.Name.Value,
                    Amount = d.Amount
                })
                .ToListAsync();

            var all = expenses.Concat(deposits).OrderByDescending(m => m.Date).ToList();
            return all;
        }
    }
}
