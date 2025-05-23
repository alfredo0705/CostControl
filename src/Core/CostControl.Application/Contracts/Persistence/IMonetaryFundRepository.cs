using CostControl.Application.DTOs.MonetaryFund;
using CostControl.Domain.Entity;

namespace CostControl.Application.Contracts.Persistence
{
    public interface IMonetaryFundRepository
    {
        Task<MonetaryFundDto> GetByIdAsync(int id);
        Task<IEnumerable<MonetaryFundDto>> GetFundsByUserIdAsync();
        Task<MonetaryFundDto> GetByUserIdAndNameAsync(string name);
        Task AddAsync(MonetaryFund monetaryFund);
        Task UpdateAsync(MonetaryFundUpdateDto monetaryFund);
        Task DeleteAsync(int id);
    }
}
