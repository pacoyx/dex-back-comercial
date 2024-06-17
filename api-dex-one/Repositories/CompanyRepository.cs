using Microsoft.EntityFrameworkCore;

public class CompanyRepository : IRepository<Company>
{
    private readonly MyDbContext _context;
    public CompanyRepository(MyDbContext context)
    {
        _context = context;
    }
    public async Task<Company?> GetById(int id)
    {
        return await _context.Companies.FindAsync(id);
    }
    public async Task<IEnumerable<Company>> GetAll()
    {
        return await _context.Companies.ToListAsync();
    }
    public async Task Create(Company company)
    {
        await _context.Companies.AddAsync(company);
    }
    public void Update(Company company)
    {
        _context.Companies.Update(company);
    }
    public void Delete(Company company)
    {
        _context.Companies.Remove(company);
    }
}