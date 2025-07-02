using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataStormApi.Data;
using DataStormApi.Models;

namespace DataStormApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgentesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgenteDto>>> GetAgentes()
        {
            var agentes = await _context.Agentes.ToListAsync();
            return agentes.Select(ToDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgenteDto>> GetAgente(int id)
        {
            var agente = await _context.Agentes.FindAsync(id);
            if (agente == null) return NotFound();
            return ToDto(agente);
        }

        [HttpPost]
        public async Task<ActionResult<AgenteDto>> PostAgente(AgenteDto dto)
        {
            var agente = new Agente
            {
                Nombre = dto.Nombre,
                NombreAgente = dto.NombreAgente,
                Apellido = dto.Apellido,
                email = dto.email,
                password = dto.password,
                rango = dto.Rango,
                Activo = dto.Activo,
                EquipoId = dto.EquipoId
            };

            _context.Agentes.Add(agente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgente), new { id = agente.Id }, ToDto(agente));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgente(int id, AgenteDto dto)
        {
            var agente = await _context.Agentes.FindAsync(id);
            if (agente == null) return NotFound();

            agente.Nombre = dto.Nombre;
            agente.NombreAgente = dto.NombreAgente;
            agente.Apellido = dto.Apellido;
            agente.email = dto.email;
            agente.password = dto.password;
            agente.rango = dto.Rango;
            agente.Activo = dto.Activo;
            agente.EquipoId = dto.EquipoId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgente(int id)
        {
            var agente = await _context.Agentes.FindAsync(id);
            if (agente == null) return NotFound();

            _context.Agentes.Remove(agente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private static AgenteDto ToDto(Agente a) => new()
        {
            Id = a.Id,
            Nombre = a.Nombre,
            NombreAgente = a.NombreAgente,
            Apellido = a.Apellido,
            email = a.email,
            password = a.password,
            Rango = a.rango,
            Activo = a.Activo,
            EquipoId = a.EquipoId
        };
    }
}
