namespace DataStormApi.Models;

public class EquipoDto
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Especialidad { get; set; }
    public int? OperacionId { get; set; }
    public List<AgenteDto>? Agentes { get; set; } // opcional
}
