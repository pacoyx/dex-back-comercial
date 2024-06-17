public static class RoleExtensions
{
    public static RoleDtoAll AsDtoAll(this Role role)
    {
        return new RoleDtoAll
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description
        };
    }

    public static Role AsRole(this CreateRoleDto createRoleDto)
    {
        return new Role
        {
            Name = createRoleDto.Name,
            Description = createRoleDto.Description,
        };
    }

    public static Role AsRole(this UpdateRoleDto updateRoleDto)
    {
        return new Role
        {
            Name = updateRoleDto.Name,
            Description = updateRoleDto.Description,
        };
    }
}