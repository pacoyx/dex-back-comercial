public interface ICompanyService
{
    Task Create(Company company);
    Task<Company?> GetById(int id);
    Task<IEnumerable<Company>> GetAll();
    Task<bool> Update(int companyId, UpdateCompanyDto company);
    Task<bool> Delete(int companyId);
}