public class CashBoxDetailService : ICashBoxDetailService
{
    private readonly IUnitOfWork _unitOfWork;
    public CashBoxDetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<CashBoxDetail>> GetAll()
    {
        return await _unitOfWork.CashBoxDetails.GetCashBoxDetails();
    }
    public async Task<CashBoxDetail?> GetById(int id)
    {
        return await _unitOfWork.CashBoxDetails.GetCashBoxDetail(id);
    }
    public async Task Add(CashBoxDetail newCashBoxDetail)
    {
        await _unitOfWork.CashBoxDetails.AddCashBoxDetail(newCashBoxDetail);
        _unitOfWork.Complete();
    }
    public async Task<bool> Update(int id, UpdateCashBoxDetailDto updatedCashBoxDetailDto)
    {
        var cashBoxDetailDB = await _unitOfWork.CashBoxDetails.GetCashBoxDetail(id);
        if (cashBoxDetailDB == null)
        {
            return false;
        }

        cashBoxDetailDB.TipoComprobante = updatedCashBoxDetailDto.TipoComprobante;
        cashBoxDetailDB.SerieComprobante = updatedCashBoxDetailDto.SerieComprobante;
        cashBoxDetailDB.NumComprobante = updatedCashBoxDetailDto.NumComprobante;
        cashBoxDetailDB.FechaComprobante = updatedCashBoxDetailDto.FechaComprobante;
        cashBoxDetailDB.Importe = updatedCashBoxDetailDto.Importe;
        cashBoxDetailDB.Adelanto = updatedCashBoxDetailDto.Adelanto;
        cashBoxDetailDB.TipoPago = updatedCashBoxDetailDto.TipoPago;
        cashBoxDetailDB.DescripcionPago = updatedCashBoxDetailDto.DescripcionPago;
        cashBoxDetailDB.Observaciones = updatedCashBoxDetailDto.Observaciones;
        cashBoxDetailDB.EstadoRegistro = updatedCashBoxDetailDto.EstadoRegistro;
        cashBoxDetailDB.UsuarioModificacion = updatedCashBoxDetailDto.UsuarioModificacion;
        cashBoxDetailDB.FechaModificacion = updatedCashBoxDetailDto.FechaModificacion;
        cashBoxDetailDB.CustomerId = updatedCashBoxDetailDto.CustomerId;

        _unitOfWork.CashBoxDetails.UpdateCashBoxDetail(cashBoxDetailDB);
        _unitOfWork.Complete();
        return true;
    }
    public async Task<bool> Delete(int id)
    {
        var cashBoxDetail = await _unitOfWork.CashBoxDetails.GetCashBoxDetail(id);
        if (cashBoxDetail == null)
        {
            return false;
        }
        _unitOfWork.CashBoxDetails.DeleteCashBoxDetail(cashBoxDetail);
        _unitOfWork.Complete();
        return true;
    }
}