using Microsoft.EntityFrameworkCore;

public class WorkShiftRepository : IRepository<WorkShift>
{
    private readonly MyDbContext _context;

    public WorkShiftRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WorkShift>> GetAll()
    {
        return await _context.WorkShifts.ToListAsync();
    }

    public async Task<WorkShift?> GetById(int id)
    {
        return await _context.WorkShifts.FindAsync(id);
    }

    public async Task Create(WorkShift workShift)
    {
        _context.WorkShifts.Add(workShift);
        await _context.SaveChangesAsync();
    }

    public void Update(WorkShift workShift)
    {
        _context.Entry(workShift).State = EntityState.Modified;
    }

    public void Delete(WorkShift workShift)
    {
        _context.WorkShifts.Remove(workShift);
    }
}