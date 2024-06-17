public interface ICashBoxDetailService
{
    Task<IEnumerable<CashBoxDetail>> GetAll();
    Task<CashBoxDetail?> GetById(int id);
    Task Add(CashBoxDetail newCashBoxDetail);
    Task<bool> Update(int id, UpdateCashBoxDetailDto updatedCashBoxDetailDto);
    Task<bool> Delete(int id);
}