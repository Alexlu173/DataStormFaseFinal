namespace DataStormApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Equipo
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? especialidad { get; set; }
    //Relacion
    [ForeignKey("Operacion")]
    public int OperacionId { get; set; }
    public Operacion? Operacion { get; set; }
    public ICollection<Agente> Agentes { get; set; } = new List<Agente>();

}