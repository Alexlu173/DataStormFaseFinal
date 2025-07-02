namespace DataStormApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



public class Agente
{
    public int Id { get; set; }
    public string? NombreAgente { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }   
    [Required]
    public string? rango { get; set; }
    public bool Activo { get; set; }
    //Relacion
    [ForeignKey("Equipo")]
    public int EquipoId { get; set; }
    public Equipo? Equipo { get; set; }
}