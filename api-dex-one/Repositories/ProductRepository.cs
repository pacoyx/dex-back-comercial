using Microsoft.EntityFrameworkCore;
public class ProductRepository : IRepository<Product>
{
    private readonly MyDbContext _context;
    public ProductRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task Create(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return null;
        }
        _context.Entry(product).State = EntityState.Detached;
        return product;
    }
}
