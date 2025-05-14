using CostControl.Application.Models.Identity;
using CostControl.Identity.Entities;

namespace CostControl.Identity.Contracts
{
    public interface IAplicationUserRepository
    {
        Task<List<AppUser>> GetUsers();
        Task<AppUser> GetUser(string id);
        Task<bool> UserExists(string user, string email);
        Task<RegistrationResponse> AddUser(RegistrationRequest registrationRequest);
        Task<bool> UpdateUser(RegistrationRequest registrationRequest);
        Task<bool> DeleteUser(string id);
        Task<AppUser?> GetByDocumentoAsync(string documentId);
        Task Save();
    }
}
