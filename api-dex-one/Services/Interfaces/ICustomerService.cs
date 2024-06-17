public interface ICustomerService
{
    Task Create(Customer customer);
    Task<Customer?> GetById(int id);
    Task<IEnumerable<Customer>> GetAll();
    Task<bool> Update(int customerId, UpdateCustomerDto customer);
    Task<bool> Delete(int customerId);
}