public class UserLoginDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";                
    public RoleDtoAll Role { get; set; } = null!;
    public int CompanyId { get; set; }    
    public string UrlImagenPerfil { get; set; } = "";            
    
}