public interface IUserPlusRepository
{
    Task<List<User>> GetUsersWithRolesAsync();
    Task<List<User>> GetUsersWithSpecificRoleAsync(string roleName);
    Task<User?> ValidateLogin(string email, string clave);
    Task<User?> GetByEmail(string email);
}