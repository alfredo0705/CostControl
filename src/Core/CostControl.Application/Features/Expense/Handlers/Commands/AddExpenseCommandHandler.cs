using CostControl.Application.Contracts.Persistence;
using CostControl.Application.Features.Expense.Requests.Commands;
using CostControl.Application.Responses;
using CostControl.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CostControl.Application.Features.Expense.Handlers.Commands
{
    public class AddExpenseCommandHandler : IRequestHandler<AddExpenseCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddExpenseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
        {
            var strategy = _unitOfWork.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _unitOfWork.BeginTransactionAsync();

                try
                {
                    var header = new Domain.Entity.Expense
                    {
                        UserId = request.ExpenseCreateDto.UserId,
                        Date = DateTime.Now,
                        MonetaryFundId = request.ExpenseCreateDto.MonetaryFundId,
                        Notes = request.ExpenseCreateDto.Notes,
                        StoreName = request.ExpenseCreateDto.StoreName,
                        DocumentType = request.ExpenseCreateDto.DocumentType,
                    };

                    var overSpent = new List<string>();

                    foreach (var detailDto in request.ExpenseCreateDto.Details)
                    {
                        var budget = await _unitOfWork.BudgetRepository.GetByUserIdTypeAndMonthAsync(
                            request.ExpenseCreateDto.UserId,
                            detailDto.ExpenseTypeId,
                            request.ExpenseCreateDto.Date.Year,
                            request.ExpenseCreateDto.Date.Month
                        );

                        var spentSoFar = await _unitOfWork.ExpenseDetailsRepository.SpentSoFar(
                            detailDto.ExpenseTypeId,
                            request.ExpenseCreateDto.UserId,
                            request.ExpenseCreateDto.Date.Year,
                            request.ExpenseCreateDto.Date.Month
                        );

                        if (budget != null && spentSoFar + detailDto.Amount > budget.Amount)
                        {
                            var exceeded = spentSoFar + detailDto.Amount - budget.Amount;
                            overSpent.Add($"Tipo de gasto ID {detailDto.ExpenseTypeId}: Excedido en {exceeded:C}, Presupuesto: {budget.Amount:C}");
                        }

                        header.Details.Add(new ExpenseDetail
                        {
                            ExpenseTypeId = detailDto.ExpenseTypeId,
                            Amount = detailDto.Amount
                        });
                    }

                    if (!header.Details.Any())
                        throw new InvalidOperationException("No se puede guardar un gasto sin detalles.");

                    if (overSpent.Any())
                        throw new InvalidOperationException($"Presupuesto excedido en:\n{string.Join("\n", overSpent)}");

                    await _unitOfWork.ExpenseRepository.CreateExpenseAsync(header);
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();

                    return new BaseCommandResponse
                    {
                        Success = true,
                        Id = header.Id
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new BaseCommandResponse
                    {
                        Success = false,
                        Message = ex.Message
                    };
                }

            });
        }
    }
}
