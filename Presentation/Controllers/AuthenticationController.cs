using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Interfaces;
using Shared.DTOs.AuthenticationDTO;

namespace Presentation.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // Login => BaseUrl/api/Authentication/login
        [HttpPost("login")]
        public async Task<ActionResult<UserResultDTO>> Login(LoginDTO loginDTO)
        {
            var result = await _authenticationService.Login(loginDTO);
            return Ok(result);
        }

        // Register => BaseUrl/api/Authentication/register
        [HttpPost("register")]
        public async Task<ActionResult<UserResultDTO>> Register(RegisterDTO registerDTO)
        {
            var result = await _authenticationService.Register(registerDTO);
            return Ok(result);
        }
    }
}
