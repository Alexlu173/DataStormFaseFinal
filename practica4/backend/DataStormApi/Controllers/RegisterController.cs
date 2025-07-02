using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataStormApi.Data;
using DataStormApi.Models;
using DataStormApi.Services;

namespace DataStormApi.Controllers;

/*
[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    private readonly AppDbContext _context;

    public RegisterController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
    {
        var salt = GenerateSalt();
        var saltedPassword = request.Password + salt;

        var agente = new Agente
        {
            NombreAgente = request.NombreAgente,
            Nombre = request.Firstname,
            Apellido = request.Lastname,
            email = request.Email,
            password = _passwordHasher.HashPassword(null, saltedPassword), // Store the salted password
            Rango = request.Rango,
            Activo = true, // Assuming new agents are active by default
        };

        await _userService.CreateAgente(agente);
        var token = _tokenService.CreateToken(agente);

        return Ok(new AuthResponse { Token = token });
    }
}
*/