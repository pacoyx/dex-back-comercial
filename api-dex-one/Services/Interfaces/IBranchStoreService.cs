public interface IBranchStoreService
{
    Task Create(BranchStore branchStore);
    Task<BranchStore?> GetById(int id);
    Task<IEnumerable<BranchStore>> GetAll();
    Task<bool> Update(int branchStoreId, BranchStore branchStore);
    Task<bool> Delete(int branchStoreId);
}