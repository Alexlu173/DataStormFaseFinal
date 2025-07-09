namespace DataStormApi.Models;

public class AgenteDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string Rango { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public int? EquipoId { get; set; }
}
