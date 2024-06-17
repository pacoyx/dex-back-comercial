using Microsoft.EntityFrameworkCore;

public class ExpenseBoxRepository : IRepository<ExpenseBox>
{
    private readonly MyDbContext _context;

    public ExpenseBoxRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ExpenseBox>> GetAll()
    {
        return await _context.ExpenseBoxes.ToListAsync();
    }

    public async Task<ExpenseBox?> GetById(int id)
    {
        var expenseBox = await _context.ExpenseBoxes.FindAsync(id);
        if (expenseBox == null)
        {
            return null;
        }
        _context.Entry(expenseBox).State = EntityState.Detached;
        return expenseBox;
    }

    public async Task Create(ExpenseBox expenseBox)
    {
        await _context.ExpenseBoxes.AddAsync(expenseBox);
    }

    public void Update(ExpenseBox expenseBox)
    {
        _context.ExpenseBoxes.Update(expenseBox);
    }

    public void Delete(ExpenseBox expenseBox)
    {
        _context.ExpenseBoxes.Remove(expenseBox);
    }
}