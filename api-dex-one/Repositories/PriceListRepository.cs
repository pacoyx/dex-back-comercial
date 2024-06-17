using Microsoft.EntityFrameworkCore;

public class PriceListRepository : IRepository<PriceListMain>
{
    private readonly MyDbContext _context;

    public PriceListRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PriceListMain>> GetAll()
    {
        return await _context.PriceListMains.ToListAsync();
    }

    public async Task<PriceListMain?> GetById(int id)
    {
        var priceListMains = await _context.PriceListMains.Include(u => u.Detalles).SingleOrDefaultAsync(z => z.Id == id);
        if (priceListMains == null)
        {
            return null;
        }
        _context.Entry(priceListMains).State = EntityState.Detached;
        return priceListMains;
    }

    public async Task Create(PriceListMain priceList)
    {
        await _context.PriceListMains.AddAsync(priceList);
    }

    public void Update(PriceListMain priceList)
    {
        _context.PriceListMains.Update(priceList);
    }

    public void Delete(PriceListMain priceList)
    {
        _context.PriceListMains.Remove(priceList);
    }

    public void DeleteDetail(PriceListDetail priceListDetail)
    {
        _context.PriceListDetails.Remove(priceListDetail);
    }
}