public interface ICashBoxDetailRepository
{
    Task<IEnumerable<CashBoxDetail>> GetCashBoxDetails();
    Task<CashBoxDetail?> GetCashBoxDetail(int id);
    Task<CashBoxDetail> AddCashBoxDetail(CashBoxDetail cashBoxDetail);
    void UpdateCashBoxDetail(CashBoxDetail cashBoxDetail);
    void DeleteCashBoxDetail(CashBoxDetail cashBoxDetail);
}