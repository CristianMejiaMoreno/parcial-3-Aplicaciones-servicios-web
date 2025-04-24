using parcial3.Data;
using parcial3.DTOs;
using parcial3.Models;
using Microsoft.EntityFrameworkCore;

namespace parcial3.Services
{
    public class EventoService
    {
        private readonly NatilleraDbContext _context;

        public EventoService(NatilleraDbContext context)
        {
            _context = context;
        }

        public async Task<Evento> CrearEventoAsync(EventoCreateDTO dto, string usuario)
        {
            var admin = _context.Administradores.FirstOrDefault(a => a.Usuario == usuario);
            if (admin == null) throw new Exception("Administrador no válido.");

            var evento = new Evento
            {
                IdAdministrador = admin.IdAministrador,
                TipoEvento = dto.TipoEvento,
                NombreEvento = dto.NombreEvento,
                TotalIngreso = dto.TotalIngreso,
                FechaEvento = dto.FechaEvento,
                Sede = dto.Sede,
                ActiviadesPlaneadas = dto.ActiviadesPlaneadas
            };

            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return evento;
        }

        public async Task<List<EventoDTO>> ObtenerEventosAsync(string usuario, string? tipo = null, string? nombre = null, DateTime? fecha = null)
        {
            var admin = await _context.Administradores.FirstOrDefaultAsync(a => a.Usuario == usuario);
            if (admin == null) return new List<EventoDTO>();

            var query = _context.Eventos
                .Where(e => e.IdAdministrador == admin.IdAministrador)
                .AsQueryable();

            if (!string.IsNullOrEmpty(tipo))
                query = query.Where(e => e.TipoEvento.Contains(tipo));

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(e => e.NombreEvento.Contains(nombre));

            if (fecha.HasValue)
                query = query.Where(e => e.FechaEvento == fecha.Value.Date);

            return await query.Select(e => new EventoDTO
            {
                IdEventos = e.IdEventos,
                TipoEvento = e.TipoEvento,
                NombreEvento = e.NombreEvento,
                TotalIngreso = e.TotalIngreso,
                FechaEvento = e.FechaEvento,
                Sede = e.Sede,
                ActiviadesPlaneadas = e.ActiviadesPlaneadas
            }).ToListAsync();
        }

        public async Task<bool> ActualizarEventoAsync(EventoUpdateDTO dto, string usuario)
        {
            var admin = await _context.Administradores.FirstOrDefaultAsync(a => a.Usuario == usuario);
            if (admin == null) return false;

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(e => e.IdEventos == dto.IdEventos && e.IdAdministrador == admin.IdAministrador);

            if (evento == null) return false;

            evento.TipoEvento = dto.TipoEvento;
            evento.NombreEvento = dto.NombreEvento;
            evento.TotalIngreso = dto.TotalIngreso;
            evento.FechaEvento = dto.FechaEvento;
            evento.Sede = dto.Sede;
            evento.ActiviadesPlaneadas = dto.ActiviadesPlaneadas;

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
