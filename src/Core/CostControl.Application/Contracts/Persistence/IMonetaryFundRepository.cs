using CostControl.Application.DTOs.MonetaryFund;
using CostControl.Domain.Entity;

namespace CostControl.Application.Contracts.Persistence
{
    public interface IMonetaryFundRepository
    {
        Task<MonetaryFundDto> GetByIdAsync(int id);
        Task<IEnumerable<MonetaryFundDto>> GetFundsByUserIdAsync(int appUserId);
        Task<MonetaryFundDto> GetByUserIdAndNameAsync(int appUserId, string name);
        Task AddAsync(MonetaryFund monetaryFund);
        Task UpdateAsync(MonetaryFundUpdateDto monetaryFund);
        Task DeleteAsync(int id);
    }
}
