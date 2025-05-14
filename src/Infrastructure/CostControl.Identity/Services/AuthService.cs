using CostControl.Application.Contracts.Identity;
using CostControl.Application.Exceptions;
using CostControl.Application.Models.Identity;
using CostControl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CostControl.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == request.Username.ToLower());

            if (user == null)
                throw new NotFoundException("Usuario no encontrado.", request.Username);

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded) throw new BadRequestException($"Credenciales para '{request.Username} no son validas'.");

            if (result.IsLockedOut) throw new BadRequestException($"Usuario '{request.Username} bloqueado'.");

            var roles = await _userManager.GetRolesAsync(user);

            AuthResponse response = new AuthResponse();

            var userDto = new AppUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            };

            if (roles == null || roles.Count == 0) throw new BadRequestException($"Usuario '{request.Username} no tiene roles asignados'.");

            response = new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                Role = roles.ToList(),
                Username = user.UserName,
                Token = await _tokenService.CreateToken(userDto),
            };

            return response;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null)
            {
                throw new Exception($"Username '{request.UserName}' already exists.");
            }

            var user = new AppUser
            {
                UserName = request.UserName,
                Email = request.Email,
                NormalizedUserName = request.UserName.ToUpper(),
                NormalizedEmail = request.Email.ToUpper(),
                EmailConfirmed = true
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail != null)
                throw new Exception($"Email {request.Email} already exists.");

            // La constraseña se genera con la primera letra del nombre, la primera letra del apellido, el documento de identidad y un asterisco
            request.Password = request.Password;
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new Exception($"{result.Errors}");

            List<string> roles = new List<string>();
            roles.Add(request.Rol);

            var roleResult = await _userManager.AddToRolesAsync(user, roles);

            if (!roleResult.Succeeded)
                throw new Exception($"{roleResult.Errors}");

            return new RegistrationResponse() { UserId = user.Id, UserName = user.UserName };
        }
    }
}
