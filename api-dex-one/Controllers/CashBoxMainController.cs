using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CashBoxMainController : ControllerBase
{
    private readonly ICashBoxMainService _cashBoxMainService;

    public CashBoxMainController(ICashBoxMainService cashBoxMainService)
    {
        _cashBoxMainService = cashBoxMainService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CashBoxMain>>> GetCashBoxMains()
    {
        var cashBox = await _cashBoxMainService.GetCashBoxMains();
        return Ok(new ApiResponse { Code = 100, Message = "Cajas encontradas", Data = cashBox });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CashBoxMain>> GetCashBoxMain(int id)
    {
        var cashBoxMain = await _cashBoxMainService.GetCashBoxMain(id);
        if (cashBoxMain == null)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Caja no encontrada", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Caja encontrada", Data = cashBoxMain });
    }

    [HttpGet("cajaPorFecha")]
    public async Task<ActionResult<IEnumerable<CashBoxDetail>>> GetCajasPorFechas(DateTime fecha, int companyId, int branchId, int userId)
    {
        var cashBoxDetails = await _cashBoxMainService.GetCashBoxByDate(fecha, companyId, branchId, userId);
        return Ok(new ApiResponse { Code = 100, Message = "Cajas encontradas", Data = cashBoxDetails });
    }

    [HttpPost]
    public async Task<ActionResult<CashBoxMain>> AddCashBoxMain(CreateCashBoxMainDto cashBoxMainDto)
    {
        var cashBoxMain = cashBoxMainDto.AsCashBoxMain();
        await _cashBoxMainService.AddCashBoxMain(cashBoxMain);
        return Ok(new ApiResponse { Code = 100, Message = "caja registrada", Data = cashBoxMain });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCashBoxMain(int id, UpdateCashBoxMainDto cashBoxMainDto)
    {
        var result = await _cashBoxMainService.UpdateCashBoxMain(id, cashBoxMainDto);
        if (!result)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Caja no encontrada", Data = null });
        }

        return Ok(new ApiResponse { Code = 100, Message = "Caja actualizada", Data = cashBoxMainDto });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCashBoxMain(int id)
    {
        var result = await _cashBoxMainService.DeleteCashBoxMain(id);
        if (!result)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Caja no encontrada", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Caja eliminada", Data = null });
    }

    [HttpPut("{id}/closeCashBox")]
    public async Task<IActionResult> CloseCashBox(int id, CashBoxCloseDto cashBoxCloseDto)
    {
        var result = await _cashBoxMainService.CloseCashBox(id, cashBoxCloseDto);
        if (!result)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Caja no encontrada", Data = null });
        }

        return Ok(new ApiResponse { Code = 100, Message = "Caja actualizada", Data = cashBoxCloseDto });
    }
}