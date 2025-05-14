using CostControl.Application.Contracts.Identity;
using CostControl.Application.Exceptions;
using CostControl.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CostControl.API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Inicia sesión y devuelve un token de autenticación.
        /// </summary>
        /// <param name="request">Datos de autenticación</param>
        /// <returns>Token de acceso</returns>
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _authService.Login(request);

                return result != null ? Ok(result) : BadRequest("Nombre de usuario o contraseña no válidos");
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Registra un nuevo usuario.
        /// </summary>
        /// <param name="request">Datos de registro</param>
        /// <returns>Datos del usuario registrado</returns>
        [HttpPost("register")]
        [ProducesResponseType(typeof(RegistrationResponse), 200)]
        [ProducesResponseType(400)]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _authService.Register(request);
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
