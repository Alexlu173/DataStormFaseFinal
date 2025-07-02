namespace DataStormApi.Models;

public class AgenteDto
{
    public int Id { get; set; }
    public string? NombreAgente { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }
    public string? Rango { get; set; }
    public bool Activo { get; set; }
    public int EquipoId { get; set; }
}
