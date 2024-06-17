public interface IProductService
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product?> GetById(int id);
    Task Create(Product product);
    Task<bool> Update(int productId, Product product);
    Task<bool> Delete(int productId);
}