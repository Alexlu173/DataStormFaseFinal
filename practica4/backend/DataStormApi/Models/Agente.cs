namespace DataStormApi.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



public class Agente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string Rango { get; set; } = string.Empty;
    public bool Activo { get; set; }
    //Relacion
    [ForeignKey("Equipo")]
    public int? EquipoId { get; set; }
    public Equipo? Equipo { get; set; }
}