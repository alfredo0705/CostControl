using AutoMapper;
using AutoMapper.QueryableExtensions;
using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.Budget;
using CostControl.Application.DTOs.BudgetVsExecute;
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

        public async Task<IEnumerable<BudgetDto>> GetByUserIdAndMonthAsync(int userId, int year, int month)
        {
            return await _context.Budgets
                .Where(b => b.AppUserId == userId && b.Year == year && b.Month == month)
                .ProjectTo<BudgetDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<BudgetDto> GetByUserIdTypeAndMonthAsync(int userId, int expenseTypeId, int year, int month)
        {
            var budget = await _context.Budgets
                .Where(b => b.AppUserId == userId && b.ExpenseTypeId == expenseTypeId && b.Year == year && b.Month == month)
                .FirstOrDefaultAsync();

            return _mapper.Map<BudgetDto>(budget);
        }

        public async Task UpdateAsync(BudgetUpdateDto budgetDto)
        {
            var budget = await _context.Budgets.FindAsync(budgetDto.Id);
            if (budget != null)
            {
                budget.Amount = budgetDto.Amount;
                budget.ExpenseTypeId = budgetDto.ExpenseTypeId;
                budget.Month = budgetDto.Month;
                budget.Year = budgetDto.Year;
            }
        }

        public async Task<List<BudgetVsExecutedDto>> GetBudgetVsExecutedAsync(int userId, BudgetExecutionFilterDto filter)
        {
            // Presupuesto por tipo de gasto en ese mes
            var budgets = await _context.Budgets
                .Where(b => b.AppUserId == userId && b.Month >= filter.From.Month && b.Month <= filter.To.Month && b.Year >= filter.From.Year && b.Year <= filter.To.Year)
                .GroupBy(b => b.ExpenseType.Name.Value)
                .Select(g => new
                {
                    ExpenseType = g.Key,
                    Budgeted = g.Sum(b => b.Amount)
                })
                .ToListAsync();

            // Gastos ejecutados por tipo de gasto en ese rango
            var expenses = await _context.ExpenseDetails
                .Where(d => d.Expense.UserId == userId
                            && d.Expense.Date >= filter.From
                            && d.Expense.Date <= filter.To)
                .GroupBy(d => d.ExpenseType.Name.Value)
                .Select(g => new
                {
                    ExpenseType = g.Key,
                    Executed = g.Sum(d => d.Amount)
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
                Month = $"{filter.From.Year}-{filter.From.Month}",
                UserId = userId
            }).ToList();

            return result;
        }
    }
}
