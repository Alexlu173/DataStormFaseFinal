using DataStormApi.Models;
using DataStormApi.Data;
using Microsoft.EntityFrameworkCore;
using DataStormApi.Controllers;

namespace DataStormApi.Services;
/*
public class AgenteService
{
    //Necesito la logica de crear el agente del registrationController
    private readonly AppDbContext _context;
    public AgenteService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Agente> CreateAgente(Agente agente)
    {
        _context.Agentes.Add(agente);
        await _context.SaveChangesAsync();
        return CreatedAction(nameof(GetAgente), new { id = agente.Id }, agente);
    }
    public async Task<Agente?> GetAgenteById(int id)
    {
        return await _context.Agentes.FindAsync(id);
    }
    public async Task<IEnumerable<Agente>> GetAllAgentes()
    {
        return await _context.Agentes.ToListAsync();
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
*/