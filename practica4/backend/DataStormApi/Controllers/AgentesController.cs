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

        // GET: api/Agentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agente>>> GetAgentes()
        {
            return await _context.Agentes.ToListAsync();
        }

        // GET: api/Agentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agente>> GetAgente(long id)
        {
            var agente = await _context.Agentes.FindAsync(id);

            if (agente == null)
            {
                return NotFound();
            }

            return agente;
        }

        // PUT: api/Agentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgente(long id, Agente agente)
        {
            if (id != agente.Id)
            {
                return BadRequest();
            }

            _context.Entry(agente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenteExists(id))
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

        // POST: api/Agentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agente>> PostAgente(Agente agente)
        {
            _context.Agentes.Add(agente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgente", new { id = agente.Id }, agente);
        }

        // DELETE: api/Agentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgente(long id)
        {
            var agente = await _context.Agentes.FindAsync(id);
            if (agente == null)
            {
                return NotFound();
            }

            _context.Agentes.Remove(agente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgenteExists(long id)
        {
            return _context.Agentes.Any(e => e.Id == id);
        }
    }
}
