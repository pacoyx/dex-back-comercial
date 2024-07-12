public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> CreateProductoAsync(Product producto)
    {
        _unitOfWork.Productos.Add(producto);
        return await _unitOfWork.CompleteAsync();
    }

    public async Task<Product> GetProductoByIdAsync(int id)
    {
        return await _unitOfWork.Productos.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllProductosAsync()
    {
        return await _unitOfWork.Productos.GetAllAsync();
    }


    public async Task<bool> Update(int productId, Product product)
    {
        var existingProduct = await _unitOfWork.Productos.GetByIdAsync(productId);
        if (existingProduct == null)
        {
            return false;
        }

        existingProduct.CodProd = product.CodProd;
        existingProduct.Nombre = product.Nombre;
        existingProduct.UniMed = product.UniMed;
        existingProduct.TipoProd = product.TipoProd;
        existingProduct.EstadoRegistro = product.EstadoRegistro;                
        existingProduct.UsuarioModificacion = product.UsuarioModificacion;
        existingProduct.FechaModificacion = DateTime.Now;
        existingProduct.CategoryId = product.CategoryId;

        _unitOfWork.Productos.Update(existingProduct);
        _unitOfWork.Complete();

        return true;
    }

    public async Task<int> UpdateProductoAsync(int id, Product product)
    {
        var existingProduct = await _unitOfWork.Productos.GetByIdAsync(id);
        if (existingProduct == null)
        {
            throw new Exception("Producto not found"); // O manejar de manera más específica según tu aplicación
        }

        existingProduct.CodProd = product.CodProd;
        existingProduct.Nombre = product.Nombre;
        existingProduct.UniMed = product.UniMed;
        existingProduct.TipoProd = product.TipoProd;
        existingProduct.EstadoRegistro = product.EstadoRegistro;
        existingProduct.UsuarioModificacion = product.UsuarioModificacion;
        existingProduct.FechaModificacion = DateTime.Now;
        existingProduct.CategoryId = product.CategoryId;

        _unitOfWork.Productos.Update(existingProduct);
        return await _unitOfWork.CompleteAsync();
    }

    public async Task<int> DeleteProductoAsync(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);
        if (producto == null)
        {
            throw new Exception("Producto not found"); // O manejar de manera más específica según tu aplicación
        }

        _unitOfWork.Productos.Remove(producto);
        return await _unitOfWork.CompleteAsync();
    }

}