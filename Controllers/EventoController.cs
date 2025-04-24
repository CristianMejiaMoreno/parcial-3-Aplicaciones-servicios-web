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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ObtenerEventos([FromQuery] string? tipo, [FromQuery] string? nombre, [FromQuery] DateTime? fecha)
        {
            var usuario = User.Identity?.Name;
            if (string.IsNullOrEmpty(usuario)) return Unauthorized();

            var eventos = await _eventoService.ObtenerEventosAsync(usuario, tipo, nombre, fecha);
            return Ok(eventos);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> ActualizarEvento([FromBody] EventoUpdateDTO dto)
        {
            var usuario = User.Identity?.Name;
            if (string.IsNullOrEmpty(usuario)) return Unauthorized();

            var actualizado = await _eventoService.ActualizarEventoAsync(dto, usuario);

            if (!actualizado)
                return NotFound(new { mensaje = "Evento no encontrado o no pertenece al usuario." });

            return Ok(new { mensaje = "Evento actualizado correctamente." });
        }

    }
}
