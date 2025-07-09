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
    public class EquiposController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquiposController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipoDto>>> GetEquipos()
        {
            var equipos = await _context.Equipos.Include(e => e.Agentes).ToListAsync();
            return equipos.Select(ToDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipoDto>> GetEquipo(int id)
        {
            var equipo = await _context.Equipos
                .Include(e => e.Agentes)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (equipo == null) return NotFound();
            return ToDto(equipo);
        }

        [HttpPost]
        public async Task<ActionResult<EquipoDto>> PostEquipo(EquipoDto dto)
        {
            var equipo = new Equipo
            {
                Nombre = dto.Nombre,
                especialidad = dto.Especialidad,
                OperacionId = dto.OperacionId
            };

            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipo), new { id = equipo.Id }, ToDto(equipo));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipo(int id, EquipoDto dto)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null) return NotFound();

            equipo.Nombre = dto.Nombre;
            equipo.especialidad = dto.Especialidad;
            equipo.OperacionId = dto.OperacionId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipo(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null) return NotFound();

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private static EquipoDto ToDto(Equipo e) => new()
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Especialidad = e.especialidad,
            OperacionId = e.OperacionId,
            Agentes = e.Agentes.Select(a => new AgenteDto
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Rango = a.Rango,
                Activo = a.Activo,
                EquipoId = a.EquipoId
            }).ToList()
        };
    }
}
