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

        modelBuilder.Entity<Equipo>()
            .HasOne(e => e.Operacion)
            .WithMany(o => o.Equipos)
            .HasForeignKey(e => e.OperacionId)
            .OnDelete(DeleteBehavior.SetNull); 

        modelBuilder.Entity<Agente>()
            .HasOne(a => a.Equipo)
            .WithMany(e => e.Agentes)
            .HasForeignKey(a => a.EquipoId)
            .OnDelete(DeleteBehavior.SetNull); 
    }

    public DbSet<Operacion> Operaciones => Set<Operacion>();
    public DbSet<Equipo> Equipos => Set<Equipo>();
    public DbSet<Agente> Agentes => Set<Agente>();

}