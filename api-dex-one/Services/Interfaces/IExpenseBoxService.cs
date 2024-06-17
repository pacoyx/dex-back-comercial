public interface IExpenseBoxService
{
    Task<IEnumerable<ExpenseBox>> GetAll();
    Task<ExpenseBox?> GetById(int id);
    Task Create(ExpenseBox expenseBox);
    Task<bool> Update(int expenseBoxId, ExpenseBox expenseBox);
    Task<bool> Delete(int expenseBoxId);
}