using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parcial3.Models
{
    [Table("Eventos")]
    public class Evento
    {
        [Key]
        public int IdEventos { get; set; }

        [ForeignKey("Administrador")]
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
