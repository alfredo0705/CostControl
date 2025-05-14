using AutoMapper;
using CostControl.Application.DTOs.Budget;
using CostControl.Application.DTOs.Deposit;
using CostControl.Application.DTOs.Expense;
using CostControl.Application.DTOs.ExpenseDetail;
using CostControl.Application.DTOs.ExpenseType;
using CostControl.Application.DTOs.MonetaryFund;
using CostControl.Domain.Entity;

namespace CostControl.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Budget, BudgetDto>().ReverseMap();
            CreateMap<Budget, BudgetUpdateDto>().ReverseMap();
            CreateMap<Budget, BudgetCreateDto>().ReverseMap();
            CreateMap<Deposit, DepositDto>().ReverseMap();
            CreateMap<Deposit, DepositUpdateDto>().ReverseMap();
            CreateMap<Deposit, DepositCreateDto>().ReverseMap();
            CreateMap<Expense, ExpenseDto>().ReverseMap();
            CreateMap<Expense, ExpenseUpdateDto>().ReverseMap();
            CreateMap<Expense, ExpenseCreateDto>().ReverseMap();
            CreateMap<ExpenseDetail, ExpenseDetailDto>().ReverseMap();
            CreateMap<ExpenseDetail, ExpenseDetailUpdateDto>().ReverseMap();
            CreateMap<ExpenseDetail, ExpenseDetailCreateDto>().ReverseMap();
            CreateMap<ExpenseType, ExpenseTypeDto>().ReverseMap();
            CreateMap<ExpenseType, ExpenseTypeUpdateDto>().ReverseMap();
            CreateMap<ExpenseType, ExpenseTypeCreateDto>().ReverseMap();
            CreateMap<MonetaryFund, MonetaryFundDto>().ReverseMap();
            CreateMap<MonetaryFund, MonetaryFundUpdateDto>().ReverseMap();
            CreateMap<MonetaryFund, MonetaryFundCreateDto>().ReverseMap();
        }
    }
}
