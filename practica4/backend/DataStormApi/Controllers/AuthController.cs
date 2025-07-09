using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DataStormApi.Services;
using DataStormApi.Models;
using DataStormApi.Data;
using Auth;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DataStormApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;
        private readonly PasswordHasher<Agente> _passwordHasher = new();

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        private static string GenerateSalt()
        {
            return Guid.NewGuid().ToString("N");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
        {
            if (await _context.Agentes.AnyAsync(a => a.Email == request.Email))
                return BadRequest("Ya existe un usuario con ese email.");

            var salt = GenerateSalt();
            var saltedPassword = request.Password + salt;

            var agente = new Agente
            {
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                Rango = request.Rango,
                Email = request.Email,
                Salt = salt,
                Password = _passwordHasher.HashPassword(null, saltedPassword),
                Activo = true
            };
            _context.Agentes.Add(agente);
            await _context.SaveChangesAsync();

            var token = _tokenService.CreateToken(agente);

            return Ok(new AuthResponse
            {
                Token = token,
                UserId = agente.Id,
                Username = agente.Nombre ?? agente.Email
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var agente = await _context.Agentes.FirstOrDefaultAsync(a => a.Email == request.Email);
            if (agente == null)
                return Unauthorized("Credenciales inválidas.");

            var result = _passwordHasher.VerifyHashedPassword(
                agente,
                agente.Password,
                request.Password + agente.Salt);

            if (result != PasswordVerificationResult.Success)
                return Unauthorized("Contraseña incorrecta.");

            var token = _tokenService.CreateToken(agente);

            return Ok(new AuthResponse
            {
                Token = token,
                UserId = agente.Id,
                Username = agente.Nombre ?? agente.Email
            });
        }
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized("No se encontró el ID del usuario en el token.");

            if (!int.TryParse(userIdClaim, out var agenteId))
                return BadRequest("El ID del agente no es válido.");

            var agente = await _context.Agentes.FindAsync(agenteId);

            if (agente == null)
                return NotFound("Agente no encontrado.");

            return Ok(new
            {
                agente.Id,
                agente.Nombre,
                agente.Apellidos,
                agente.Email,
                agente.Rango,
                agente.Activo
            });
        }
    }

}
