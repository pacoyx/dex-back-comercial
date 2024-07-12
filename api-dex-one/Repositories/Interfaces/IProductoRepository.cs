namespace api_dex_one.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        void Add(Product producto);
        void Update(Product producto);
        void Remove(Product producto);
    }
}
