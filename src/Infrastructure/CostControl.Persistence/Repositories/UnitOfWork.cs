using AutoMapper;
using CostControl.Application.Constants;
using CostControl.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;

namespace CostControl.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CostControlDbContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(CostControlDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IExpenseTypeRepository ExpenseTypeRepository => new ExpenseTypeRepository(_context, _mapper);
        public IMonetaryFundRepository MonetaryFundRepository => new MonetaryFundRepository(_context, _mapper);
        public IBudgetRepository BudgetRepository => new BudgetRepository(_context, _mapper);
        public IExpenseRepository ExpenseRepository => new ExpenseRepository(_context);
        public IExpenseDetailsRepository ExpenseDetailsRepository => new ExpenseDetailsRepository(_context);
        public IDepositRepository DepositRepository => new DepositRepository(_context);


        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public async Task SaveAsync()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            if (!string.IsNullOrWhiteSpace(username))
                await _context.SaveChangesAsync(username);
            else
                await _context.SaveChangesAsync("SYSTEM");
        }
        public IExecutionStrategy CreateExecutionStrategy()
        {
            return _context.Database.CreateExecutionStrategy();
        }

    }
}
