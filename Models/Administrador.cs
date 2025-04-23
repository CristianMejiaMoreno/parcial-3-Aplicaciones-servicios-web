using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parcial3.Models
{
    [Table("Administrador")]
    public class Administrador
    {
        [Key]
        public int IdAministrador { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

        public ICollection<Evento> Eventos { get; set; }
    }
}
