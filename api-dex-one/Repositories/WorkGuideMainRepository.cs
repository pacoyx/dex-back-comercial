using Microsoft.EntityFrameworkCore;

public class WorkGuideMainRepository : IWorkGuideMainRepository
{
    private readonly MyDbContext _context;

    public WorkGuideMainRepository(MyDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<WorkGuideMain>> GetWorkGuideMains()
    {
        return await _context.WorkGuideMains
            .Include(w => w.Customer)
            .Include(w => w.WorkGuideDetails)
            .ToListAsync();
    }

    public async Task<WorkGuideMain?> GetWorkGuideMain(int id)
    {
        return await _context.WorkGuideMains.FindAsync(id);
    }

    public async Task<WorkGuideMain> AddWorkGuideMain(WorkGuideMain workGuideMain)
    {
        await _context.WorkGuideMains.AddAsync(workGuideMain);
        return workGuideMain;
    }

    public void UpdateWorkGuideMain(WorkGuideMain workGuideMain)
    {
        _context.WorkGuideMains.Update(workGuideMain);
    }

    public void DeleteWorkGuideMain(WorkGuideMain workGuideMain)
    {
        _context.WorkGuideMains.Remove(workGuideMain);
    }

    public async Task<IEnumerable<WorkGuideMain>> GetWorkGuideByDates(DateTime fechaIni, DateTime fechaFin, int companyId, int branch)
    {
        return await _context.WorkGuideMains
            .Include(w => w.Customer)
            .Where(w => w.FechaOperacion >= fechaIni && w.FechaOperacion <= fechaFin && w.CompanyId == companyId)
            .ToListAsync();
    }
}