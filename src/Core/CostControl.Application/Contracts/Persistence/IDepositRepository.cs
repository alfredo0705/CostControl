using CostControl.Domain.Entity;

namespace CostControl.Application.Contracts.Persistence
{
    public interface IDepositRepository
    {
        Task AddDeposit(Deposit deposit);
        Task<bool> DepositByMonetaryFundExists(int monetariFundId);
    }
}
