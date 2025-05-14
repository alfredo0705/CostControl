using CostControl.Application.Models.Identity;
using CostControl.Identity.Contracts;
using CostControl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CostControl.Identity.Repositories
{
    public class AplicationUserRepository : IAplicationUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AplicationUserRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager;
        }

        public async Task<AppUser?> GetByDocumentoAsync(string documentId)
        {
            var appUser = await _userManager.Users
                .FirstOrDefaultAsync(u => u.DocumentId == documentId);

            if (appUser is null) return null;

            return new AppUser
            {
                Id = appUser.Id,
                UserName = appUser.UserName!,
                Email = appUser.Email!,
                DocumentId = new(appUser.DocumentId)
            };
        }

        public async Task<RegistrationResponse> AddUser(RegistrationRequest registrationRequest)
        {
            var existingUser = await _userManager.FindByNameAsync(registrationRequest.UserName);

            if (existingUser != null)
            {
                throw new Exception($"Username '{registrationRequest.UserName}' already exists.");
            }


            // Crear el rol si no existe
            if (!await _roleManager.RoleExistsAsync(registrationRequest.Rol))
            {
                var role = new AppRole { Name = registrationRequest.Rol };
                var roleResult = await _roleManager.CreateAsync(role);

                if (!roleResult.Succeeded)
                    throw new Exception($"Error al crear el rol {registrationRequest.Rol}.");
            }

            var user = new AppUser
            {
                FirstName = registrationRequest.FirstName, 
                LastName = registrationRequest.LastName,
                DocumentId = new(registrationRequest.DocumentId),
                UserName = registrationRequest.UserName,
                Email = registrationRequest.Email,
                NormalizedUserName = registrationRequest.UserName.ToUpper(),
                NormalizedEmail = registrationRequest.Email.ToUpper(),
                EmailConfirmed = true,
                Address = registrationRequest.Address,
                Birthdate = registrationRequest.Birthdate,
            };

            var existingEmail = await _userManager.FindByEmailAsync(registrationRequest.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, registrationRequest.Password);

                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByNameAsync(registrationRequest.Rol);
                    if (role == null)
                        throw new Exception($"Error al crear el rol {registrationRequest.Rol}.");

                    await _userManager.AddToRoleAsync(user, registrationRequest.Rol);
                    return new RegistrationResponse() { UserId = user.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new Exception($"Email {registrationRequest.Email} already exists.");
            }
        }

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var result = await _userManager.DeleteAsync(user);

            return result.Succeeded;
        }

        public async Task<AppUser> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<List<AppUser>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUser(RegistrationRequest registrationRequest)
        {
            var user = await _userManager.FindByIdAsync(registrationRequest.Id);

            if (user != null)
            {
                var result = await _userManager.AddPasswordAsync(user, registrationRequest.Password);

                return result.Succeeded;
            }

            return false;
        }

        public Task<bool> UserExists(string user, string email)
        {
            throw new NotImplementedException();
        }
    }
}
