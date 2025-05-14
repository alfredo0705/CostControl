using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.ExpenseType.Validators;
using CostControl.Application.Features.ExpenseType.Requests.Commands;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.ExpenseType.Handlers.Commands
{
    public class UpdateExpenseTypeCommandHandler : IRequestHandler<UpdateExpenseTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExpenseTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(UpdateExpenseTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var validator = new ExpenseTypeUpdateDtoValidator();
                var validationResult = validator.Validate(request.ExpenseTypeUpdateDto);

                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creación fallida";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                    return response;
                }

                await _unitOfWork.ExpenseTypeRepository.UpdateAsync(request.ExpenseTypeUpdateDto);
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
