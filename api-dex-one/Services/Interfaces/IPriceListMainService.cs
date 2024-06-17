public interface IPriceListMainService
{
    Task<IEnumerable<PriceListMain>> GetAll();
    Task<PriceListMain?> GetById(int id);
    Task Create(PriceListMain listPrice);
    Task<bool> Update(int listPriceId, UpdatePriceListDto listPrice);
    Task<bool> Delete(int listPriceId);
}