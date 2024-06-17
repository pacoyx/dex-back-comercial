using System.ComponentModel.DataAnnotations;

public class UpdateUserDto
{
    [Required]
    public int Id { get; set; }
    [MinLength(2)]
    public string Name { get; set; } = "";
    [EmailAddress]
    public string Email { get; set; } = "";
    public required string PasswordHash { get; set; }
    public required string RoleNameShort { get; set; }
    public byte[] Salt { get; set; } = new byte[16];
    public int RoleId { get; set; }
    public int CompanyId { get; set; }
    public string Observaciones { get; set; } = "";
    public string UrlImagenPerfil { get; set; } = "";
}