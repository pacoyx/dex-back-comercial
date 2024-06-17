public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string RoleNameShort { get; set; } = "";
    public byte[] Salt { get; set; } = new byte[16];

}