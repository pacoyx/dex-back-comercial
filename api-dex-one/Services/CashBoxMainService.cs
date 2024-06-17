
public class CashBoxMainService : ICashBoxMainService
{
    private readonly IUnitOfWork _unitOfWork;

    public CashBoxMainService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CashBoxMain>> GetCashBoxMains()
    {
        return await _unitOfWork.CashBoxMains.GetCashBoxMains();
    }

    public async Task<CashBoxMain?> GetCashBoxMain(int id)
    {
        return await _unitOfWork.CashBoxMains.GetCashBoxMain(id);
    }

    public async Task AddCashBoxMain(CashBoxMain cashBoxMain)
    {
        await _unitOfWork.CashBoxMains.AddCashBoxMain(cashBoxMain);
        _unitOfWork.Complete();
    }

    public async Task<bool> UpdateCashBoxMain(int id, UpdateCashBoxMainDto cashBoxMainDto)
    {
        if (cashBoxMainDto == null)
        {
            return false;
        }
        if (id != cashBoxMainDto.Id)
        {
            return false;
        }

        var cashBoxMainToUpdate = await _unitOfWork.CashBoxMains.GetCashBoxMain(id);
        if (cashBoxMainToUpdate == null)
        {
            return false;
        }

        cashBoxMainToUpdate.FechaCaja = cashBoxMainDto.FechaCaja;
        cashBoxMainToUpdate.FechaHoraApertura = cashBoxMainDto.FechaHoraApertura;
        cashBoxMainToUpdate.FechaHoraCierre = cashBoxMainDto.FechaHoraCierre;
        cashBoxMainToUpdate.EstadoCaja = cashBoxMainDto.EstadoCaja;
        cashBoxMainToUpdate.SaldoInicial = cashBoxMainDto.SaldoInicial;
        cashBoxMainToUpdate.SaldoFinal = cashBoxMainDto.SaldoFinal;
        cashBoxMainToUpdate.TotalIngreso = cashBoxMainDto.TotalIngreso;
        cashBoxMainToUpdate.TotalSalida = cashBoxMainDto.TotalSalida;
        cashBoxMainToUpdate.Observaciones = cashBoxMainDto.Observaciones;
        cashBoxMainToUpdate.UsuarioModificacion = cashBoxMainDto.UsuarioModificacion;
        cashBoxMainToUpdate.FechaModificacion = cashBoxMainDto.FechaModificacion;
        cashBoxMainToUpdate.BranchStoreId = cashBoxMainDto.BranchStoreId;
        cashBoxMainToUpdate.WorkShiftId = cashBoxMainDto.WorkShiftId;

        _unitOfWork.CashBoxMains.UpdateCashBoxMain(cashBoxMainToUpdate);
        _unitOfWork.Complete();
        return true;
    }

    public async Task<bool> DeleteCashBoxMain(int cashBoxMainId)
    {
        var cashBoxMainToDelete = await _unitOfWork.CashBoxMains.GetCashBoxMain(cashBoxMainId);
        if (cashBoxMainToDelete == null)
        {
            return false;
        }

        _unitOfWork.CashBoxMains.DeleteCashBoxMain(cashBoxMainToDelete);
        return true;
    }

    public async Task<IEnumerable<CashBoxByDateDto>> GetCashBoxByDate(DateTime fecha, int companyId, int branchId, int userId)
    {
        return await _unitOfWork.CashBoxMains.GetCashBoxByDate(fecha, companyId, branchId, userId);
    }

    public async Task<bool> CloseCashBox(int id, CashBoxCloseDto cashBoxCloseDto)
    {

        if (cashBoxCloseDto == null)
        {
            return false;
        }
        if (id != cashBoxCloseDto.Id)
        {
            return false;
        }

        if (cashBoxCloseDto.EstadoCaja == "C")
        {
            return false;
        }

        var cashBoxMainToUpdate = await _unitOfWork.CashBoxMains.GetCashBoxMain(id);
        if (cashBoxMainToUpdate == null)
        {
            return false;
        }

        cashBoxMainToUpdate.FechaHoraCierre = cashBoxCloseDto.FechaHoraCierre;
        cashBoxMainToUpdate.EstadoCaja = cashBoxCloseDto.EstadoCaja;
        cashBoxMainToUpdate.SaldoFinal = cashBoxCloseDto.SaldoFinal;
        cashBoxMainToUpdate.TotalIngreso = cashBoxCloseDto.TotalIngreso;
        cashBoxMainToUpdate.TotalSalida = cashBoxCloseDto.TotalSalida;
        cashBoxMainToUpdate.ObservacionesCierre = cashBoxCloseDto.ObservacionesCierre;

        _unitOfWork.CashBoxMains.UpdateCashBoxMain(cashBoxMainToUpdate);
        _unitOfWork.Complete();
        return true;
    }
}
