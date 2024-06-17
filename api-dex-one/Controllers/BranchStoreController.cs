using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class BranchStoreController : ControllerBase
{
    private readonly IBranchStoreService _branchStoreService;

    public BranchStoreController(IBranchStoreService branchStoreService)
    {
        _branchStoreService = branchStoreService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SelectAllBranchStoreDto>>> GetAllBranchStores()
    {
        var branchStores = await _branchStoreService.GetAll();
        return Ok(new ApiResponse { Code = 100, Message = "Sucursales encontradas", Data = branchStores.Select(bs => bs.AsSelectAllBranchStoreDto()) });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BranchStore>> GetBranchStoreById(int id)
    {
        var branchStore = await _branchStoreService.GetById(id);
        if (branchStore == null)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Sucursal no encontrada", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Sucursal encontrada", Data = branchStore.AsSelectAllBranchStoreDto() });
    }

    [HttpPost]
    public async Task<ActionResult<BranchStore>> CreateBranchStore(CreateBranchStoreDto branchStoreDto)
    {
        var branchStore = branchStoreDto.AsBranchStore();
        await _branchStoreService.Create(branchStore);
        return Ok(new ApiResponse { Code = 100, Message = "Sucursal creada", Data = branchStore.AsSelectAllBranchStoreDto() });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBranchStore(int id, UpdateBranchStoreDto branchStoreDto)
    {
        if (id != branchStoreDto.Id)
        {
            return BadRequest(new ApiResponse { Code = 99, Message = "Request incorrecto", Data = null });
        }

        var branchStore = branchStoreDto.AsBranchStore();
        var updated = await _branchStoreService.Update(id, branchStore);
        if (!updated)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Sucursal no encontrada", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Sucursal actualizada", Data = branchStore.AsSelectAllBranchStoreDto() });
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBranchStore(int id)
    {
        var deleted = await _branchStoreService.Delete(id);
        if (!deleted)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Sucursal no encontrada", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Sucursal eliminada", Data = null });
    }
}
