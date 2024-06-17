public class BranchStoreService : IBranchStoreService
{
    private readonly IUnitOfWork _unitOfWork;

    public BranchStoreService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Create(BranchStore branchStore)
    {
        await _unitOfWork.BranchStores.Create(branchStore);
        _unitOfWork.Complete();
    }

    public async Task<BranchStore?> GetById(int id)
    {
        return await _unitOfWork.BranchStores.GetById(id);
    }
    
    public async Task<IEnumerable<BranchStore>> GetAll()
    {
        return await _unitOfWork.BranchStores.GetAll();
    }

    public async Task<bool> Update(int branchStoreId, BranchStore branchStore)
    {
        var branchStoreToUpdate = await _unitOfWork.BranchStores.GetById(branchStoreId);
        if (branchStoreToUpdate == null)
        {
            return false;
        }
        branchStoreToUpdate.Descripcion = branchStore.Descripcion;
        branchStoreToUpdate.Direccion = branchStore.Direccion;
        branchStoreToUpdate.EstadoRegistro = branchStore.EstadoRegistro;
        branchStoreToUpdate.EstadoLogico = branchStore.EstadoLogico;
        branchStoreToUpdate.UsuarioRegistro = branchStore.UsuarioRegistro;
        branchStoreToUpdate.UsuarioModificacion = branchStore.UsuarioModificacion;
        branchStoreToUpdate.FechaRegistro = branchStore.FechaRegistro;
        branchStoreToUpdate.FechaModificacion = branchStore.FechaModificacion;
        branchStoreToUpdate.CompanyId = branchStore.CompanyId;
        
        _unitOfWork.BranchStores.Update(branchStoreToUpdate);
        _unitOfWork.Complete();
        return true;
    }

    public async Task<bool> Delete(int branchStoreId)
    {
        var branchStoreToDelete = await _unitOfWork.BranchStores.GetById(branchStoreId);
        if (branchStoreToDelete == null)
        {
            return false;
        }
        _unitOfWork.BranchStores.Delete(branchStoreToDelete);
        _unitOfWork.Complete();
        return true;
    }

}
