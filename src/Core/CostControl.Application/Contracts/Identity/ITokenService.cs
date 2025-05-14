using CostControl.Application.Models.Identity;

namespace CostControl.Application.Contracts.Identity
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUserDto user);
    }
}
