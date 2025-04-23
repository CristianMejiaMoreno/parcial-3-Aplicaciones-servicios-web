using System.ComponentModel.DataAnnotations;

namespace parcial3.Models
{
    public class Evento
    {
        public int IdEventos { get; set; }
        public int IdAdministrador { get; set; }
        public string TipoEvento { get; set; }
        public string NombreEvento { get; set; }
        public int TotalIngreso { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Sede { get; set; }
        public string ActiviadesPlaneadas { get; set; }

        public Administrador Administrador { get; set; }
    }
}
