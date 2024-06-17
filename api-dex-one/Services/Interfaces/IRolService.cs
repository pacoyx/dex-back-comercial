public interface IRolService
{
    Task Create(Role rol);
    Task<Role?> GetById(int id);
    Task<IEnumerable<Role>> GetAll();
    Task<bool> Update(int rolId, Role role);
    Task<bool> Delete(int rolId);
}
