using Microsoft.EntityFrameworkCore;
public class CategoryProdRepository : IRepository<CategoryProd>
{
    private readonly MyDbContext _context;
    public CategoryProdRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task Create(CategoryProd categoryProd)
    {
        await _context.CategoryProds.AddAsync(categoryProd);
    }

    public void Delete(CategoryProd categoryProd)
    {
        _context.CategoryProds.Remove(categoryProd);
    }

    public async Task<IEnumerable<CategoryProd>> GetAll()
    {
        return await _context.CategoryProds.ToListAsync<CategoryProd>();
    }

    public async Task<CategoryProd?> GetById(int id)
    {
        var cat = await _context.CategoryProds.FindAsync(id);
        if (cat == null)
        {
            return null;
        }
        _context.Entry(cat).State = EntityState.Detached;

        return cat;
    }

    public void Update(CategoryProd categoryProd)
    {
        _context.CategoryProds.Update(categoryProd);
    }
}
