using System.ComponentModel.DataAnnotations;

namespace Auth;

public class RegistrationRequest
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Rango { get; set; } = string.Empty;
}
