public interface ICategoryProdService 
{
    Task Create(CategoryProd categoryProd);
    Task<CategoryProd?> GetById(int id);
    Task<IEnumerable<CategoryProd>> GetAll();
    Task<bool> Update(int categoryProdId, CategoryProd categoryProd);
    Task<bool> Delete(int categoryProdId);
}