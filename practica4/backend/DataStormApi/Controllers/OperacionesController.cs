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
    public class OperacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OperacionesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperacionDto>>> GetOperaciones()
        {
            var operaciones = await _context.Operaciones
                .Include(o => o.Equipos)
                    .ThenInclude(e => e.Agentes)
                .ToListAsync();

            return operaciones.Select(ToDto).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OperacionDto>> GetOperacion(int id)
        {
            var operacion = await _context.Operaciones
                .Include(o => o.Equipos)
                    .ThenInclude(e => e.Agentes)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (operacion == null) return NotFound();
            return ToDto(operacion);
        }

        [HttpPost]
        public async Task<ActionResult<OperacionDto>> PostOperacion(OperacionDto dto)
        {
            var operacion = new Operacion
            {
                Nombre = dto.Nombre,
                Estado = Enum.Parse<Operacion.EstadoOperacion>(dto.Estado),
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin
            };

            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOperacion), new { id = operacion.Id }, ToDto(operacion));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperacion(int id, OperacionDto dto)
        {
            var operacion = await _context.Operaciones.FindAsync(id);
            if (operacion == null) return NotFound();

            operacion.Nombre = dto.Nombre;
            operacion.Estado = Enum.Parse<Operacion.EstadoOperacion>(dto.Estado);
            operacion.FechaInicio = dto.FechaInicio;
            operacion.FechaFin = dto.FechaFin;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperacion(int id)
        {
            var operacion = await _context.Operaciones.FindAsync(id);
            if (operacion == null) return NotFound();

            _context.Operaciones.Remove(operacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private static OperacionDto ToDto(Operacion o) => new()
        {
            Id = o.Id,
            Nombre = o.Nombre,
            Estado = o.Estado.ToString(),
            FechaInicio = o.FechaInicio,
            FechaFin = o.FechaFin,
            Equipos = o.Equipos.Select(e => new EquipoDto
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
            }).ToList()
        };
    }
}
