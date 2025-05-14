namespace CostControl.Application.Contracts.Persistence
{
    public interface IExpenseDetailsRepository
    {
        Task<decimal> SpentSoFar(int expenseTypeId, int userId, int year, int month);
    }
}
