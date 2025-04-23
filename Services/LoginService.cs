using Microsoft.EntityFrameworkCore;
using parcial3.Data;
using parcial3.DTOs;
using parcial3.Auth;

namespace parcial3.Services
{
    public class LoginService
    {
        private readonly NatilleraDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginService(NatilleraDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTO> AutenticarAsync(LoginDTO login)
        {
            var admin = await _context.Administradores
                .FirstOrDefaultAsync(a => a.Usuario == login.Usuario && a.Clave == login.Clave);

            if (admin == null)
            {
                return new LoginResponseDTO
                {
                    Autenticado = false,
                    Mensaje = "Usuario o clave incorrectos"
                };
            }

            var token = TokenGenerator.GenerateTokenJwt(admin.Usuario, _configuration);

            return new LoginResponseDTO
            {
                Usuario = admin.Usuario,
                Autenticado = true,
                Token = token,
                Mensaje = "Login exitoso"
            };
        }
    }
}
