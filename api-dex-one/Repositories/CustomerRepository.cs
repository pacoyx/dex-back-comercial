using Microsoft.EntityFrameworkCore;
public class CustomerRepository : IRepository<Customer>
{
    private readonly MyDbContext _context;
    public CustomerRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetById(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task Create(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public void Update(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
    }

    public void Delete(Customer customer)
    {
        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }
}