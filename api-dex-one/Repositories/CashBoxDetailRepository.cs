using Microsoft.EntityFrameworkCore;

public class CashBoxDetailRepository : ICashBoxDetailRepository
{
    private readonly MyDbContext _context;

    public CashBoxDetailRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CashBoxDetail>> GetCashBoxDetails()
    {
        return await _context.CashBoxDetails.ToListAsync();
    }

    public async Task<CashBoxDetail?> GetCashBoxDetail(int id)
    {
        var det = await _context.CashBoxDetails.FindAsync(id);
        if (det == null)
        {
            return null;
        }
        _context.Entry(det).State = EntityState.Detached;

        return det;
    }

    public async Task<CashBoxDetail> AddCashBoxDetail(CashBoxDetail cashBoxDetail)
    {
        await _context.CashBoxDetails.AddAsync(cashBoxDetail);
        return cashBoxDetail;
    }

    public void UpdateCashBoxDetail(CashBoxDetail cashBoxDetail)
    {
        _context.CashBoxDetails.Update(cashBoxDetail);
    }

    public void DeleteCashBoxDetail(CashBoxDetail cashBoxDetail)
    {
        _context.CashBoxDetails.Remove(cashBoxDetail);
    }
}