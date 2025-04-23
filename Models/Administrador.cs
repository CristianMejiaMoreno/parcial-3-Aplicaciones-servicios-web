namespace parcial3.Models
{
    public class Administrador
    {
        public int IdAministrador { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

        public ICollection<Evento> Eventos { get; set; }
    }
}
