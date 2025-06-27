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

        // GET: api/Operaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operacion>>> GetOperaciones()
        {
            return await _context.Operaciones.ToListAsync();
        }

        // GET: api/Operaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operacion>> GetOperacion(long id)
        {
            var operacion = await _context.Operaciones.FindAsync(id);

            if (operacion == null)
            {
                return NotFound();
            }

            return operacion;
        }

        // PUT: api/Operaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperacion(long id, Operacion operacion)
        {
            if (id != operacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(operacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Operaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Operacion>> PostOperacion(Operacion operacion)
        {
            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperacion", new { id = operacion.Id }, operacion);
        }

        // DELETE: api/Operaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperacion(long id)
        {
            var operacion = await _context.Operaciones.FindAsync(id);
            if (operacion == null)
            {
                return NotFound();
            }

            _context.Operaciones.Remove(operacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperacionExists(long id)
        {
            return _context.Operaciones.Any(e => e.Id == id);
        }
    }
}
