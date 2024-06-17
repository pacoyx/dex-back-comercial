using Microsoft.EntityFrameworkCore;

public class RoleRepository : IRepository<Role>
{
    private readonly MyDbContext _context;
    public RoleRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task Create(Role role)
    {
        await _context.Roles.AddAsync(role);
    }

    public void Delete(Role role)
    {
        _context.Roles.Remove(role);
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        return await _context.Roles.ToListAsync<Role>();
    }

    public async Task<Role?> GetById(int id)
    {
        var rol = await _context.Roles.FindAsync(id);
        if (rol == null)
        {
            return null;
        }
        _context.Entry(rol).State = EntityState.Detached;

        return rol;
    }

    public void Update(Role role)
    {
        _context.Roles.Update(role);
    }
}

