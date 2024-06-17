public class CreateUserDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; } 
    public required string RoleNameShort { get; set; } 
    public int RoleId { get; set; }
    public int CompanyId { get; set; }
    public string Observaciones { get; set; } = "";
    public string UrlImagenPerfil { get; set; } = "";    
 
}