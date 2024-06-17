public interface ICashBoxMainRepository
{
    Task<IEnumerable<CashBoxMain>> GetCashBoxMains();
    Task<CashBoxMain?> GetCashBoxMain(int id);
    Task<CashBoxMain> AddCashBoxMain(CashBoxMain cashBoxMain);
    void UpdateCashBoxMain(CashBoxMain cashBoxMain);
    void DeleteCashBoxMain(CashBoxMain cashBoxMain);
    Task<IEnumerable<CashBoxByDateDto>> GetCashBoxByDate(DateTime fecha,int companyId, int branchId, int userId);
    void CloseCashBox(CashBoxMain cashBoxMain);
}