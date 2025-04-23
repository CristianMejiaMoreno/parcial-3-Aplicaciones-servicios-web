namespace parcial3.DTOs
{
    public class LoginResponseDTO
    {
        public string Usuario { get; set; }
        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public string Mensaje { get; set; }
    }
}
