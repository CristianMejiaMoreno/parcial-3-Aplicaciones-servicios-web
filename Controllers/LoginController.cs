using Microsoft.AspNetCore.Mvc;
using parcial3.DTOs;
using parcial3.Services;

namespace parcial3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var resultado = await _loginService.AutenticarAsync(loginDto);

            if (!resultado.Autenticado)
            {
                return Unauthorized(resultado);
            }

            return Ok(resultado);
        }
    }
}
