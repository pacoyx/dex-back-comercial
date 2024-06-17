public interface IService<T>
{
    Task Create(T Entity);
    Task<T?> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<bool> Update(int id, T Entity);
    Task<bool> Delete(int id);
}