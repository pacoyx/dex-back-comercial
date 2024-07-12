using api_dex_one.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductoRepository
{
    private readonly MyDbContext _dbContext;
    public ProductRepository(MyDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _dbContext.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public void Add(Product producto)
    {
        _dbContext.Products.Add(producto);
    }

    public void Update(Product producto)
    {
        _dbContext.Products.Update(producto);
    }

    public void Remove(Product producto)
    {
        _dbContext.Products.Remove(producto);
    }
}
