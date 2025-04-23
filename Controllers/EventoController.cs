using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using parcial3.DTOs;
using parcial3.Services;
using System.Security.Claims;

namespace parcial3.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly EventoService _eventoService;

        public EventoController(EventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearEvento([FromBody] EventoCreateDTO dto)
        {
            var usuario = User.FindFirst(ClaimTypes.Name)?.Value;
            if (usuario == null) return Unauthorized("Token no válido");

            var eventoCreado = await _eventoService.CrearEventoAsync(dto, usuario);
            return Ok(eventoCreado);
        }
    }
}
