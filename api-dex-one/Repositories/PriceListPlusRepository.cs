public class PriceListPlusRepository : IPriceListPlusRepository
{
    private readonly MyDbContext _context;

    public PriceListPlusRepository(MyDbContext context)
    {
        _context = context;
    }

    public void DeleteDetail(PriceListDetail priceListDetail)
    {
        _context.PriceListDetails.Remove(priceListDetail);
    }
}