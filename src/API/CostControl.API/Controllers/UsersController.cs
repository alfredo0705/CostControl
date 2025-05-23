using CostControl.Application.Models.Identity;
using CostControl.Identity.Contracts;
using CostControl.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CostControl.API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IAplicationUserRepository _userRepository;

        public UsersController(IAplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("getUsers")]
        public async Task<ActionResult<List<AppUser>>> GetUsers()
        {
            return Ok(await _userRepository.GetUsers());
        }

        [HttpGet("getUser")]
        public async Task<ActionResult<AppUser>> GetUser(string id)
        {
            return Ok(await _userRepository.GetUser(id));
        }

        [HttpPost("addUser")]
        public async Task<ActionResult> AddUser(RegistrationRequest appUserDto)
        {
            try
            {
                return Ok(await _userRepository.AddUser(appUserDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateUser")]
        public async Task<ActionResult> UpdateUser(RegistrationRequest registrationRequest)
        {
            try
            {
                var result = await _userRepository.UpdateUser(registrationRequest);

                if (result)
                    return NoContent();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteUser")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            try
            {
                if (await _userRepository.DeleteUser(id))
                    return NoContent();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
