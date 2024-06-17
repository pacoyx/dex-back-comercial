public class CategoryProdService : ICategoryProdService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryProdService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Create(CategoryProd categoryProd)
    {
        categoryProd.FechaRegistro = DateTime.Now;
        await _unitOfWork.CategoryProds.Create(categoryProd);
        _unitOfWork.Complete();
    }

    public async Task<CategoryProd?> GetById(int id)
    {
        return await _unitOfWork.CategoryProds.GetById(id);
    }

    public async Task<IEnumerable<CategoryProd>> GetAll()
    {
        return await _unitOfWork.CategoryProds.GetAll();
    }

    public async Task<bool> Update(int categoryProdId, CategoryProd categoryProd)
    {
        var existingCategoryProd = await _unitOfWork.CategoryProds.GetById(categoryProdId);
        if (existingCategoryProd == null)
        {
            return false;
        }

        existingCategoryProd.Descripcion = categoryProd.Descripcion;
        existingCategoryProd.EstadoRegistro = categoryProd.EstadoRegistro;                
        existingCategoryProd.UsuarioModificacion = categoryProd.UsuarioModificacion;
        existingCategoryProd.FechaModificacion = DateTime.Now;

        _unitOfWork.Complete();

        return true;
    }

    public async Task<bool> Delete(int categoryProdId)
    {
        var existingCategoryProd = await _unitOfWork.CategoryProds.GetById(categoryProdId);

        if (existingCategoryProd == null)
        {
            return false;
        }

        _unitOfWork.CategoryProds.Delete(existingCategoryProd);
        _unitOfWork.Complete();

        return true;
    }
}