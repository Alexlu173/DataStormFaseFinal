using Microsoft.EntityFrameworkCore;
using DataStormApi.Models;

namespace DataStormApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Operacion>()
            .Property(o => o.Estado)
            .HasConversion<string>(); // Guarda el enum como texto
    }

    public DbSet<Operacion> Operaciones => Set<Operacion>();
    public DbSet<Equipo> Equipos => Set<Equipo>();
    public DbSet<Agente> Agentes => Set<Agente>();

}