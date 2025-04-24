using System;

namespace parcial3.DTOs
{
    public class EventoUpdateDTO
    {
        public int IdEventos { get; set; }
        public string TipoEvento { get; set; }
        public string NombreEvento { get; set; }
        public int TotalIngreso { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Sede { get; set; }
        public string ActiviadesPlaneadas { get; set; }
    }
}
