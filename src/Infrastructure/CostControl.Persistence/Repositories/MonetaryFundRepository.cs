using AutoMapper;
using AutoMapper.QueryableExtensions;
using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.MonetaryFund;
using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CostControl.Persistence.Repositories
{
    public class MonetaryFundRepository : IMonetaryFundRepository
    {
        private readonly CostControlDbContext _context;
        private readonly IMapper _mapper;

        public MonetaryFundRepository(CostControlDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(MonetaryFund monetaryFund)
        {
            await _context.MonetaryFunds.AddAsync(monetaryFund);
        }

        public async Task DeleteAsync(int id)
        {
            var monetary = await _context.MonetaryFunds.FindAsync(id);
            if (monetary != null)
            {
                monetary.IsDeleted = true;
                monetary.DeletedDate = DateTime.Now;

                _context.MonetaryFunds.Update(monetary);
            }
        }

        public async Task<MonetaryFundDto> GetByIdAsync(int id)
        {
            var monetary = await _context.MonetaryFunds.FindAsync(id);
            return _mapper.Map<MonetaryFundDto>(monetary);
        }

        public async Task<MonetaryFundDto> GetByUserIdAndNameAsync(int appUserId, string name)
        {
            var monetary = await _context.MonetaryFunds.Where(m => m.AppUserId == appUserId && m.Name.Value == name).FirstOrDefaultAsync();

            return _mapper.Map<MonetaryFundDto>(monetary);
        }

        public async Task<IEnumerable<MonetaryFundDto>> GetFundsByUserIdAsync(int appUserId)
        {
            return await _context.MonetaryFunds
                .AsNoTracking()
                .Where(m => m.AppUserId == appUserId)
                .ProjectTo<MonetaryFundDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task UpdateAsync(MonetaryFundUpdateDto monetaryFundDto)
        {
            var monetary = await _context.MonetaryFunds.FindAsync(monetaryFundDto.Id);
            monetary.Name = new(monetaryFundDto.Name);
            monetary.CurrentBalance = monetaryFundDto.CurrentBalance;
            monetary.Type = monetaryFundDto.Type;

            _context.MonetaryFunds.Update(monetary);
        }
    }
}
