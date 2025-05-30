using AutoMapper;
using AutoMapper.QueryableExtensions;
using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.Budget;
using CostControl.Application.DTOs.BudgetVsExecute;
using CostControl.Application.DTOs.Movement;
using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CostControl.Persistence.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly CostControlDbContext _context;
        private readonly IMapper _mapper;

        public BudgetRepository(CostControlDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(Budget budget)
        {
            await _context.Budgets.AddAsync(budget);
        }

        public async Task DeleteAsync(int id)
        {
            var budget = await _context.Budgets.FindAsync(id);

            if (budget != null)
            {
                budget.IsDeleted = true;
                budget.DeletedDate = DateTime.Now;

                _context.Budgets.Update(budget);
            }
        }

        public async Task<BudgetDto?> GetByIdAsync(int id)
        {
            var budget = await _context.Budgets.FindAsync(id);

            return _mapper.Map<BudgetDto>(budget);
        }

        public async Task<IEnumerable<BudgetDto>> GetByUserIdAndMonthAsync(int userId, DateTime period)
        {
            return await _context.Budgets
                .Where(b => b.AppUserId == userId && b.Period.Year == period.Year && b.Period.Month == period.Month)
                .ProjectTo<BudgetDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<BudgetDto> GetByUserIdTypeAndMonthAsync(int userId, int expenseTypeId, DateTime period)
        {
            var budget = await _context.Budgets
                .Where(b => b.AppUserId == userId && b.ExpenseTypeId == expenseTypeId && b.Period.Year == period.Year && b.Period.Month == period.Month)
                .FirstOrDefaultAsync();

            return _mapper.Map<BudgetDto>(budget);
        }

        public async Task<bool> GetByExpenseTypeAsync(int expenseTypeId)
        {
            return await _context.Budgets
                .AnyAsync(b => b.ExpenseTypeId == expenseTypeId);
        }

        public async Task UpdateAsync(BudgetUpdateDto budgetDto)
        {
            var budget = await _context.Budgets.FindAsync(budgetDto.Id);
            if (budget != null)
            {
                budget.Amount = budgetDto.Amount;

                _context.Budgets.Update(budget);
            }
        }

        public async Task<List<BudgetVsExecutedDto>> GetBudgetVsExecutedAsync(int userId, BudgetExecutionFilterDto filter)
        {
            var budgets = await _context.Budgets
                .Where(b => b.AppUserId == userId && b.Period >= filter.From && b.Period <= filter.To)
                .GroupBy(b => new { b.Period, b.ExpenseType.Name.Value})
                .Select(g => new
                {
                    ExpenseType = g.Key.Value,
                    Budgeted = g.Sum(b => b.Amount),
                    Period = g.Key.Period
                })
                .ToListAsync();

            // Gastos ejecutados por tipo de gasto en ese rango
            var expenses = await _context.ExpenseDetails
                .Where(d => d.Expense.UserId == userId
                            && d.Expense.Date >= filter.From
                            && d.Expense.Date <= filter.To)
                .GroupBy(d => new {d.Expense.Date, d.ExpenseType.Name.Value})
                .Select(g => new
                {
                    ExpenseType = g.Key.Value,
                    Executed = g.Sum(d => d.Amount),
                    Period = g.Key.Date
                })
                .ToListAsync();

            // Unir ambas listas
            var allTypes = budgets.Select(b => b.ExpenseType)
                .Union(expenses.Select(e => e.ExpenseType))
                .Distinct();

            var result = allTypes.Select(type => new BudgetVsExecutedDto
            {
                ExpenseType = type,
                BudgetedAmount = budgets.FirstOrDefault(b => b.ExpenseType == type)?.Budgeted ?? 0,
                ExecutedAmount = expenses.FirstOrDefault(e => e.ExpenseType == type)?.Executed ?? 0,
                Period = budgets.FirstOrDefault(b => b.ExpenseType == type)?.Period ?? new DateTime(0),
                UserId = userId
            }).ToList();

            return result;
        }

        public async Task<List<MovementDto>> GetMovementsAsync(int userId, MovementFilterDto filter)
        {
            // Gastos
            var expenses = await _context.ExpenseDetails
                .Where(d => d.Expense.UserId == userId &&
                            d.Expense.Date >= filter.From &&
                            d.Expense.Date <= filter.To)
                .Select(d => new MovementDto
                {
                    MovementType = "Gasto",
                    Date = d.Expense.Date,
                    FundName = d.Expense.MonetaryFund.Name.Value,
                    Amount = d.Amount,
                    ExpenseType = d.ExpenseType.Name.Value,
                    StoreName = d.Expense.StoreName,
                    DocumentType = d.Expense.DocumentType
                })
                .ToListAsync();

            // Depósitos
            var deposits = await _context.Deposits
                .Where(d => d.UserId == userId &&
                            d.Date >= filter.From &&
                            d.Date <= filter.To)
                .Select(d => new MovementDto
                {
                    MovementType = "Depósito",
                    Date = d.Date,
                    FundName = d.MonetaryFund.Name.Value,
                    Amount = d.Amount,
                    ExpenseType = null,
                    StoreName = null,
                    DocumentType = null
                })
                .ToListAsync();

            // Unir y ordenar por fecha
            var result = expenses
                .Concat(deposits)
                .OrderBy(m => m.Date)
                .ToList();

            return result;
        }

    }
}
