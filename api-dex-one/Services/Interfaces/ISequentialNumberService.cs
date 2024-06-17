public interface ISequentialNumberService
{
    Task<IEnumerable<SequentialNumber>> GetAll();
    Task<SequentialNumber?> GetById(int id);
    Task Create(SequentialNumber sequentialNumber);
    Task<bool> Update(int sequentialNumberId, UpdateSequentialNumberDto sequentialNumber);
    Task<bool> Delete(int sequentialNumberId);
}