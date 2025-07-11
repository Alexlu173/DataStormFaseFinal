namespace DataStormApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Operacion
{
    public enum EstadoOperacion
    {
        Planificada,
        Activa,
        Completada
    }
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public EstadoOperacion Estado { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    //Relacion
    public ICollection<Equipo>? Equipos { get; set; } = new List<Equipo>();
}