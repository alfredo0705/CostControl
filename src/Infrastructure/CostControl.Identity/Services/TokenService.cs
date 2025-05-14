using CostControl.Application.Contracts.Identity;
using CostControl.Application.Models.Identity;
using CostControl.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CostControl.Identity.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<AppUser> _userManager;
        private readonly CostControlIdentityDbContext _context;
        private readonly JwtSettings _jwtSettings;

        public TokenService(IConfiguration config, UserManager<AppUser> userManager, IOptions<JwtSettings> jwtSettings, CostControlIdentityDbContext context)
        {
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]));
            _context = context;
            _jwtSettings = jwtSettings.Value ?? throw new ArgumentNullException(nameof(jwtSettings.Value));
        }

        public async Task<string> CreateToken(AppUserDto userDto)
        {
            var user = await _userManager.FindByNameAsync(userDto.UserName);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim (JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim (JwtRegisteredClaimNames.UniqueName, user.UserName),
            };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = creds,
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
