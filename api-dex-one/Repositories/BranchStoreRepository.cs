using Microsoft.EntityFrameworkCore;

public class BranchStoreRepository : IRepository<BranchStore>
{
    private readonly MyDbContext _context;

    public BranchStoreRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BranchStore>> GetAll()
    {
        return await _context.BranchStores.ToListAsync();
    }

    public async Task<BranchStore?> GetById(int id)
    {
        var branch = await _context.BranchStores.FindAsync(id);
        if (branch == null)
        {
            return null;
        }
        _context.Entry(branch).State = EntityState.Detached;
        return branch;
    }

    public async Task Create(BranchStore branchStore)
    {
        await _context.BranchStores.AddAsync(branchStore);
    }

    public void Update(BranchStore branchStore)
    {
        _context.BranchStores.Update(branchStore);
    }

    public void Delete(BranchStore branchStore)
    {
        _context.BranchStores.Remove(branchStore);
    }
}