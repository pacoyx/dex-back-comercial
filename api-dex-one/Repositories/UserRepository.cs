using Microsoft.EntityFrameworkCore;

public class UserRepository : IRepository<User>
{
    private readonly MyDbContext _context;

    public UserRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task Create(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync<User>();
    }

    public async Task<User?> GetById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }
        _context.Entry(user).State = EntityState.Detached;

        return user;
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }
}