public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string RoleNameShort { get; set; } = "";
    public byte[] Salt { get; set; } = new byte[16];
     // Clave foránea
    public int RoleId { get; set; }
    // Navegación a Role
    public Role Role { get; set; } = null!;
    public int CompanyId { get; set; }
    public string Observaciones { get; set; } = "";
    public string UrlImagenPerfil { get; set; } = "";    
    public string EstadoLogico { get; set; } = "";
    public string EstadoRegistro { get; set; } = "";
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public DateTime FechaModificacion { get; set; } = DateTime.Now;    
    
}