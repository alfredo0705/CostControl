using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.ExpenseType.Validators;
using CostControl.Application.Features.ExpenseType.Requests.Commands;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.ExpenseType.Handlers.Commands
{
    public class AddExpenseTypeCommandHandler : IRequestHandler<AddExpenseTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddExpenseTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(AddExpenseTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var validator = new ExpenseTypeCreateDtoValidator();
                var validationResult = validator.Validate(request.ExpenseTypeCreateDto);

                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creación fallida";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                    return response;
                }

                var expensiveType = new Domain.Entity.ExpenseType
                {
                    Code = await _unitOfWork.ExpenseTypeRepository.GenerateNextExpenseTypeCodeAsync(),
                    Description = new(request.ExpenseTypeCreateDto.Description),
                    Name = new(request.ExpenseTypeCreateDto.Name)
                };

                await _unitOfWork.ExpenseTypeRepository.AddAsync(expensiveType);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Message = "Creación exitosa";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
