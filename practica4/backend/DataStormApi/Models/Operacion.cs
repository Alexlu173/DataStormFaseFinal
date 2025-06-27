namespace DataStormApi.Models;

public class Operacion
{
    public enum EstadoOperacion
    {
        Planificada,
        Activa,
        Completada
    }

    public long Id { get; set; }
    public string? Nombre { get; set; }
    public EstadoOperacion Estado { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    //Relacion
    public ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}