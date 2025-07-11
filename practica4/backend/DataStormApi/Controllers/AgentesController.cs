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
                Apellidos = dto.Apellidos,
                Email = dto.Email,
                Password = dto.Password,
                Rango = dto.Rango,
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
            agente.Apellidos = dto.Apellidos;
            agente.Email = dto.Email;
            agente.Password = dto.Password;
            agente.Rango = dto.Rango;
            agente.Activo = dto.Activo;
            agente.EquipoId = dto.EquipoId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}/equipo")]
        public async Task<IActionResult> ActualizarEquipoDelAgente(int id, [FromBody] AsignarEquipoRequest request)
        {
            var agente = await _context.Agentes.FindAsync(id);
            if (agente == null)
                return NotFound("Agente no encontrado.");

            agente.EquipoId = request.EquipoId;

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
            Apellidos = a.Apellidos,
            Email = a.Email,
            Password = a.Password,
            Rango = a.Rango,
            Activo = a.Activo,
            EquipoId = a.EquipoId
        };
    }
}
