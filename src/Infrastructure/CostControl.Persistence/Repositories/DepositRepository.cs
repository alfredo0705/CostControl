using CostControl.Application.Contracts.Persistence;
using CostControl.Domain.Entity;

namespace CostControl.Persistence.Repositories
{
    public class DepositRepository : IDepositRepository
    {
        private readonly CostControlDbContext _context;

        public DepositRepository(CostControlDbContext context)
        {
            _context = context;
        }

        public async Task AddDeposit(Deposit deposit)
        {
            await _context.Deposits.AddAsync(deposit);
        }
    }
}
