using parcial3.Data;
using parcial3.DTOs;
using parcial3.Models;

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
    }
}
