using Microsoft.EntityFrameworkCore;
public class SequentialNumberRepository : IRepository<SequentialNumber>
{
    private readonly MyDbContext _context;
    public SequentialNumberRepository(MyDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<SequentialNumber>> GetAll()
    {
        return await _context.SequentialNumbers.ToListAsync();
    }
    public async Task<SequentialNumber?> GetById(int id)
    {
        return await _context.SequentialNumbers.FindAsync(id);
    }
    public async Task Create(SequentialNumber sequentialNumber)
    {
        await _context.SequentialNumbers.AddAsync(sequentialNumber);
        await _context.SaveChangesAsync();
    }
    public void Update(SequentialNumber sequentialNumber)
    {
        _context.SequentialNumbers.Update(sequentialNumber);
        _context.SaveChanges();
    }
    public void Delete(SequentialNumber sequentialNumber)
    {
        _context.SequentialNumbers.Remove(sequentialNumber);
        _context.SaveChanges();
    }
}