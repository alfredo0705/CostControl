using AutoMapper;
using AutoMapper.QueryableExtensions;
using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.ExpenseType;
using CostControl.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CostControl.Persistence.Repositories
{
    public class ExpenseTypeRepository : IExpenseTypeRepository
    {
        private readonly CostControlDbContext _context;
        private readonly IMapper _mapper;

        public ExpenseTypeRepository(CostControlDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(ExpenseType expenseTypeDto)
        {
            await _context.ExpenseTypes.AddAsync(expenseTypeDto);
        }

        public async Task DeleteAsync(int id)
        {
            var type = await _context.ExpenseTypes.FindAsync(id);
            if (type != null)
            {
                type.IsDeleted = true;
                type.DeletedDate = DateTime.Now;

                _context.ExpenseTypes.Update(type);
            }
        }

        public async Task<string> GenerateNextExpenseTypeCodeAsync()
        {
            var lastCode = await _context.ExpenseTypes
                .OrderByDescending(et => et.Id)
                .Select(et => et.Code)
                .FirstOrDefaultAsync();

            if (string.IsNullOrWhiteSpace(lastCode))
                return "G001";

            int lastNumber = int.Parse(lastCode.Substring(1));
            return $"G{(lastNumber + 1).ToString("D3")}";
        }

        public async Task<IEnumerable<ExpenseTypeDto>> GetAllAsync()
        {
            return await _context.ExpenseTypes
                .AsNoTracking()
                .Where(et => !et.IsDeleted)
                .OrderBy(et => et.Name.Value)
                .ProjectTo<ExpenseTypeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ExpenseTypeDto> GetByIdAsync(int id)
        {
            var type = await _context.ExpenseTypes.FindAsync(id);

            return _mapper.Map<ExpenseTypeDto>(type);
        }

        public async Task UpdateAsync(ExpenseTypeUpdateDto expenseTypeDto)
        {
            var type = await _context.ExpenseTypes.FindAsync(expenseTypeDto.Id);

            if (type != null)
            {
                type.Description = new(expenseTypeDto.Description);
                type.Name = new(expenseTypeDto.Name);
            }
        }
    }
}
