using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _productService.GetAll();
        return Ok(new ApiResponse { Code = 100, Message = "Productos encontradas", Data = products.Select(p => p.AsSelectAllProductDto())});
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SelectAllProductDto>> GetProductById(int id)
    {
        var product = await _productService.GetById(id);
        if (product == null)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Producto no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Producto encontrado", Data = product.AsSelectAllProductDto() });
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        var product = createProductDto.AsProduct();
        await _productService.Create(product);
        return Ok(new ApiResponse { Code = 100, Message = "Producto creado", Data = product.AsSelectAllProductDto() });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto productDto)
    {
        if (id != productDto.Id)
        {
            return BadRequest(new ApiResponse { Code = 99, Message = "request incorrecto", Data = null });
        }

        var product = productDto.AsProduct();
        var updated = await _productService.Update(id, product);
        if (!updated)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Producto no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Producto actualizado", Data = product.AsSelectAllProductDto() });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var deleted = await _productService.Delete(id);
        if (!deleted)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Producto no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Producto eliminado", Data = null });
    }
}