public interface ICashBoxMainService
{
    Task<IEnumerable<CashBoxMain>> GetCashBoxMains();
    Task<CashBoxMain?> GetCashBoxMain(int id);
    Task AddCashBoxMain(CashBoxMain cashBoxMain);
    Task<bool> UpdateCashBoxMain(int id, UpdateCashBoxMainDto cashBoxMainDto);
    Task<bool> DeleteCashBoxMain(int cashBoxMainId);
    Task<IEnumerable<CashBoxByDateDto>> GetCashBoxByDate(DateTime fecha, int companyId, int branchId, int userId);
    Task<bool> CloseCashBox(int id, CashBoxCloseDto cashBoxCloseDto);
}