public class SequentialNumberService : ISequentialNumberService
{
    private readonly IUnitOfWork _unitOfWork;
    public SequentialNumberService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<SequentialNumber>> GetAll()
    {
        return await _unitOfWork.SequentialNumbers.GetAll();
    }
    public async Task<SequentialNumber?> GetById(int id)
    {
        return await _unitOfWork.SequentialNumbers.GetById(id);
    }
    public async Task Create(SequentialNumber sequentialNumber)
    {
        await _unitOfWork.SequentialNumbers.Create(sequentialNumber);
    }
    public async Task<bool> Update(int sequentialNumberId, UpdateSequentialNumberDto sequentialNumberDto)
    {
        var sequentialDb = await _unitOfWork.SequentialNumbers.GetById(sequentialNumberDto.Id);
        if (sequentialDb == null)
        {
            return false;
        }
        sequentialDb.CodSucursal = sequentialNumberDto.CodSucursal;
        sequentialDb.TipoDoc = sequentialNumberDto.TipoDoc;
        sequentialDb.SerieDoc = sequentialNumberDto.SerieDoc;
        sequentialDb.NumDoc = sequentialNumberDto.NumDoc;
        sequentialDb.EstadoRegistro = sequentialNumberDto.EstadoRegistro;
        sequentialDb.UsuarioModificacion = sequentialNumberDto.UsuarioModificacion;
        sequentialDb.FechaModificacion = DateTime.Now;

        _unitOfWork.SequentialNumbers.Update(sequentialDb);
        return true;
    }
    public async Task<bool> Delete(int sequentialNumberId)
    {
        var sequential = await _unitOfWork.SequentialNumbers.GetById(sequentialNumberId);
        if (sequential == null)
        {
            return false;
        }
        _unitOfWork.SequentialNumbers.Delete(sequential);
        return true;
    }
}