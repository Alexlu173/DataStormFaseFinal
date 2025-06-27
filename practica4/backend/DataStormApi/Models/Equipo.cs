namespace DataStormApi.Models;

public class Equipo
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public string? especialidad { get; set; }
    //Relacion
    public int OperacionId { get; set; }
    public Operacion? Operacion { get; set; }
    public ICollection<Agente> Agentes { get; set; } = new List<Agente>();

}