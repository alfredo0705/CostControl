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

        public async Task<MonetaryFundDto> GetByUserIdAndNameAsync(string name)
        {
            var monetary = await _context.MonetaryFunds.Where(m => m.Name.Value == name).FirstOrDefaultAsync();

            return _mapper.Map<MonetaryFundDto>(monetary);
        }

        public async Task<IEnumerable<MonetaryFundDto>> GetFundsByUserIdAsync()
        {
            return await _context.MonetaryFunds
                .Include(d => d.Deposits)
                .Include(e => e.Expenses)
                    .ThenInclude(ed => ed.Details)
                .AsNoTracking()
                .Where(m => !m.IsDeleted)
                .ProjectTo<MonetaryFundDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task UpdateAsync(MonetaryFundUpdateDto monetaryFundDto)
        {
            var monetary = await _context.MonetaryFunds.FindAsync(monetaryFundDto.Id);
            monetary.Name = new(monetaryFundDto.Name);
            monetary.InitialBalance = monetaryFundDto.InitialBalance;
            monetary.Type = monetaryFundDto.Type;

            _context.MonetaryFunds.Update(monetary);
        }
    }
}
