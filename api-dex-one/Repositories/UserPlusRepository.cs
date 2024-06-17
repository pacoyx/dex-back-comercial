using Microsoft.EntityFrameworkCore;
public class UserPlusRepository : IUserPlusRepository
{
    private readonly MyDbContext _context;
    public UserPlusRepository(MyDbContext context)
    {
        _context = context;
    }
    public async Task<List<User>> GetUsersWithRolesAsync()
    {
        return await _context.Users
            .Include(u => u.Role) // Carga los roles relacionados
            .ToListAsync();
    }

    public async Task<List<User>> GetUsersWithSpecificRoleAsync(string roleName)
    {
        return await _context.Users
            .Include(u => u.Role) // Carga los roles relacionados
            .Where(u => u.Role.Name == roleName) // Filtra los usuarios por rol
            .ToListAsync();
    }

    public async Task<User?> ValidateLogin(string email, string clave)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == clave);
    }

    public async Task<User?> GetByEmail(string email)
    {
        var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }
}