public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Create(Product product)
    {
        product.FechaRegistro = DateTime.Now;
        product.FechaModificacion = DateTime.Now;
        await _unitOfWork.Products.Create(product);
        _unitOfWork.Complete();
    }

    public async Task<Product?> GetById(int id)
    {
        return await _unitOfWork.Products.GetById(id);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _unitOfWork.Products.GetAll();
    }

    public async Task<bool> Update(int productId, Product product)
    {
        var existingProduct = await _unitOfWork.Products.GetById(productId);
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

        _unitOfWork.Products.Update(existingProduct);
        _unitOfWork.Complete();

        return true;
    }

    public async Task<bool> Delete(int productId)
    {
        var existingProduct = await _unitOfWork.Products.GetById(productId);

        if (existingProduct == null)
        {
            return false;
        }

        _unitOfWork.Products.Delete(existingProduct);
        _unitOfWork.Complete();

        return true;
    }
}