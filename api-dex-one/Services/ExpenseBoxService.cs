public class ExpenseBoxService : IExpenseBoxService
{
    private readonly IUnitOfWork _unitOfWork;

    public ExpenseBoxService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ExpenseBox>> GetAll()
    {
        return await _unitOfWork.ExpenseBoxes.GetAll();
    }

    public async Task<ExpenseBox?> GetById(int id)
    {
        return await _unitOfWork.ExpenseBoxes.GetById(id);
    }

    public async Task Create(ExpenseBox expenseBox)
    {
        await _unitOfWork.ExpenseBoxes.Create(expenseBox);
    }

    public async Task<bool> Update(int expenseBoxId, ExpenseBox expenseBox)
    {
        var expenseBoxDb = await _unitOfWork.ExpenseBoxes.GetById(expenseBoxId);
        if (expenseBoxDb == null)
        {
            return false;
        }

        expenseBox.EstadoLogico = expenseBoxDb.EstadoLogico;
        expenseBox.UsuarioRegistro = expenseBoxDb.UsuarioRegistro;
        expenseBox.FechaRegistro = expenseBoxDb.FechaRegistro;
        expenseBox.CompanyId = expenseBoxDb.CompanyId;

        _unitOfWork.ExpenseBoxes.Update(expenseBox);
        return true;
    }

    public async Task<bool> Delete(int expenseBoxId)
    {
        var expenseBoxToDelete = await _unitOfWork.ExpenseBoxes.GetById(expenseBoxId);
        if (expenseBoxToDelete == null)
        {
            return false;
        }
        _unitOfWork.ExpenseBoxes.Delete(expenseBoxToDelete);
        return true;
    }
}