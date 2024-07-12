public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductosAsync();
    Task<Product> GetProductoByIdAsync(int id);
    Task<int> CreateProductoAsync(Product producto);
    Task<int> UpdateProductoAsync(int id, Product producto);
    Task<int> DeleteProductoAsync(int id);
}