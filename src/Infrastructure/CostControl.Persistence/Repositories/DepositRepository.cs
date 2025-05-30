using CostControl.Application.Contracts.Persistence;
using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> DepositByMonetaryFundExists(int monetariFundId)
        {
            return await _context.Deposits.AnyAsync(d => d.MonetaryFundId == monetariFundId);
        }
    }
}
