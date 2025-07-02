namespace DataStormApi.Models;

public class OperacionDto
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string Estado { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public List<EquipoDto>? Equipos { get; set; } // opcional
}
