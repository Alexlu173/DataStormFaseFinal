using DataStormApi.Models;
using DataStormApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DataStormApi.Services;

public class OperacionService
{
    private readonly AppDbContext _context;
    public OperacionService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Operacion> GetAll()
    {
        return _context.Operaciones
            .AsNoTracking()
            .ToList();
    }
}