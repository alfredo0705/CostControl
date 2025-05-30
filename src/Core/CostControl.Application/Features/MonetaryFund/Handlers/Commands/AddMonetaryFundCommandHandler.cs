using CostControl.Application.Contracts.Persistence;
using CostControl.Application.DTOs.MonetaryFund.Validators;
using CostControl.Application.Features.MonetaryFund.Requests.Commands;
using CostControl.Application.Responses;
using MediatR;

namespace CostControl.Application.Features.MonetaryFund.Handlers.Commands
{
    public class AddMonetaryFundCommandHandler : IRequestHandler<AddMonetaryFundCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMonetaryFundCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(AddMonetaryFundCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                var validatior = new MonetaryFundCreateDtoValidator();
                var validationResult = validatior.Validate(request.MonetaryFundCreateDto);
                if (validationResult.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "Creación fallida";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                    return response;
                }

                var monetaryFund = new Domain.Entity.MonetaryFund
                {
                    Name = new(request.MonetaryFundCreateDto.Name),
                    Type = request.MonetaryFundCreateDto.Type,
                    InitialBalance = request.MonetaryFundCreateDto.InitialBalance,
                };

                await _unitOfWork.MonetaryFundRepository.AddAsync(monetaryFund);
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
