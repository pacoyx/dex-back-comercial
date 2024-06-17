using System.Data.Common;
using System.Text;


public static class UserExtensions
{
    public static UserDto AsDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            RoleNameShort = user.RoleNameShort,
            PasswordHash = user.PasswordHash,
            Salt = user.Salt,
        };
    }

    public static UserLoginDto AsDtoLogin(this User user)
    {
        return new UserLoginDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role.AsDtoAll(),
            CompanyId = user.CompanyId,
            UrlImagenPerfil = user.UrlImagenPerfil,
        };
    }

    public static UserDtoAll AsDtoAll(this User user)
    {
        return new UserDtoAll
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            RoleNameShort = user.RoleNameShort,
            PasswordHash = "*****",
        };
    }

    public static UserDtoWithRolesAll AsDtoAllWithRoles(this User user)
    {
        return new UserDtoWithRolesAll
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            RoleNameShort = user.RoleNameShort,
            PasswordHash = "*****",            
            Role = user.Role.AsDtoAll(),
        };
    }

    public static User AsUser(this CreateUserDto createUserDto)
    {
        return new User
        {
            Name = createUserDto.Name,
            Email = createUserDto.Email,
            PasswordHash = createUserDto.PasswordHash,
            RoleNameShort = createUserDto.RoleNameShort,
            RoleId = createUserDto.RoleId,
            CompanyId = createUserDto.CompanyId,
            Observaciones = createUserDto.Observaciones,
            UrlImagenPerfil = createUserDto.UrlImagenPerfil,
            EstadoLogico = "A",
            EstadoRegistro = "A",
            FechaRegistro = DateTime.Now,
            FechaModificacion = DateTime.Now,
        };
    }

    public static User AsUser(this UpdateUserDto updateUserDto)
    {
        return new User
        {
            Id = updateUserDto.Id,
            Name = updateUserDto.Name,
            Email = updateUserDto.Email,
            PasswordHash = updateUserDto.PasswordHash,
            RoleNameShort = updateUserDto.RoleNameShort,
            RoleId = updateUserDto.RoleId,              
            CompanyId = updateUserDto.CompanyId,
            Observaciones = updateUserDto.Observaciones,
            UrlImagenPerfil = updateUserDto.UrlImagenPerfil,          
            FechaModificacion = DateTime.Now,
        };
    }
}