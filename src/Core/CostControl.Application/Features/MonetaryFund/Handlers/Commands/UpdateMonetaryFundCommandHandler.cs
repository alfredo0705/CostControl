using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.MonetaryFund.Validators;
using CostControl.Application.Features.MonetaryFund.Requests.Commands;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.MonetaryFund.Handlers.Commands
{
    public class UpdateMonetaryFundCommandHandler : IRequestHandler<UpdateMonetaryFundCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMonetaryFundCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(UpdateMonetaryFundCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                var validator = new MonetaryFundUpdateDtoValidator();
                var validationResult = validator.Validate(request.MonetaryFundUpdateDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Actualización fallida";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                    return response;
                }

                await _unitOfWork.MonetaryFundRepository.UpdateAsync(request.MonetaryFundUpdateDto);
                await _unitOfWork.SaveAsync();

                response.Success = true;
                response.Message = "Actualización exitosa";
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
