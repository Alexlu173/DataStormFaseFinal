namespace DataStormApi.Models;

public class Agente
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public string? rango { get; set; }
    public bool Activo { get; set; }
    //Relacion
    public int EquipoId { get; set; }
    public Equipo? Equipo { get; set; }
    
}