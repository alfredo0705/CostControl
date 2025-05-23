using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.Deposit.Validators;
using CostControl.Application.Features.Deposit.Requests.Commands;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.Deposit.Handlers.Commands
{
    public class AddDepositCommandHandler : IRequestHandler<AddDepositCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddDepositCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(AddDepositCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                var validator = new DepositCreateDtoValidator();
                var validationResult = validator.Validate(request.DepositCreateDto);
                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Error guardando";

                    return response;
                }

                var deposit = new Domain.Entity.Deposit
                {
                    Amount = request.DepositCreateDto.Amount,
                    Date = request.DepositCreateDto.Date,
                    MonetaryFundId = request.DepositCreateDto.MonetaryFundId,
                    UserId = request.DepositCreateDto.UserId,
                };

                await _unitOfWork.DepositRepository.AddDeposit(deposit);



                await _unitOfWork.SaveAsync();

                response.Success = true;

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
