using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoryProdController : ControllerBase
{
    private readonly ICategoryProdService _categoryProdService;

    public CategoryProdController(ICategoryProdService categoryProdService)
    {
        _categoryProdService = categoryProdService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryProd>>> GetAll()
    {
        var categories = await _categoryProdService.GetAll();
        return Ok(new ApiResponse { Code = 100, Message = "Categorias encontradas", Data = categories });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SelectAllCategoryProdDto>> GetById(int id)
    {
        var category = await _categoryProdService.GetById(id);
        if (category == null)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Categoria no encontrada", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Categoria encontrada", Data = category.AsSelectAllCatProdDto() });
    }

    [HttpPost]
    public async Task<ActionResult<CategoryProd>> Create(CreateCategoryProdDto createCategoryProdDto)
    {
        var category = createCategoryProdDto.AsCategoryProd();
        await _categoryProdService.Create(category);        
        return Ok(new ApiResponse { Code = 100, Message = "Categoria creada correctamente", Data = category.AsSelectAllCatProdDto() });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCategoryProdDto updateCategoryProdDto)
    {
        if (id != updateCategoryProdDto.Id)
        {
            return BadRequest(new ApiResponse { Code = 99, Message = "request incorrecto", Data = null });
        }

        var category = updateCategoryProdDto.AsCategoryProd();
        var resultUpdate = await _categoryProdService.Update(id, category);
        if (!resultUpdate)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Categoria no encontrada", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Categoria actualizada correctamente", Data = null });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedCategory = await _categoryProdService.Delete(id);
        if (!deletedCategory)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Categoria no encontrada", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Categoria eliminada correctamente", Data = null });
    }
}