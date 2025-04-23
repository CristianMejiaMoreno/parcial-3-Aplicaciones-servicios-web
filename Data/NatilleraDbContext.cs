using Microsoft.EntityFrameworkCore;
using parcial3.Models;

namespace parcial3.Data
{
    public class NatilleraDbContext : DbContext
    {
        public NatilleraDbContext(DbContextOptions<NatilleraDbContext> options) : base(options) { }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Evento> Eventos { get; set; }
    }
}
