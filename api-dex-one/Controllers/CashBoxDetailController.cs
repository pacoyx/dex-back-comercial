using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CashBoxDetailController : ControllerBase
{
    private readonly ICashBoxDetailService _cashBoxDetailService;

    public CashBoxDetailController(ICashBoxDetailService cashBoxDetailService)
    {
        _cashBoxDetailService = cashBoxDetailService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CashBoxDetail>>> GetAll()
    {
        var cashBoxDetails = await _cashBoxDetailService.GetAll();
        return Ok(new ApiResponse { Code = 100, Message = "pagos encontrados", Data = cashBoxDetails });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CashBoxDetail>> GetById(int id)
    {
        var cashBoxDetail = await _cashBoxDetailService.GetById(id);
        if (cashBoxDetail is null)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "pago no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Cliente encontrado", Data = cashBoxDetail });
    }

    [HttpPost]
    public async Task<ActionResult<CashBoxDetail>> Create(CreateCashBoxDetailDto cashBoxDetailDto)
    {
        var cashBoxDetail = cashBoxDetailDto.AsCashBoxDetail();
        await _cashBoxDetailService.Add(cashBoxDetail);
        return Ok(new ApiResponse { Code = 100, Message = "Pago registrado", Data = cashBoxDetail });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCashBoxDetailDto cashBoxDetailDto)
    {
        if (id != cashBoxDetailDto.Id)
        {
            return BadRequest(new ApiResponse { Code = 99, Message = "Request incorrecto", Data = null });
        }

        var updated = await _cashBoxDetailService.Update(id, cashBoxDetailDto);
        if (!updated)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Pago no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Pago actualizado", Data = cashBoxDetailDto });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _cashBoxDetailService.Delete(id);
        if (!deleted)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Pago no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Pago eliminado", Data = null });
    }
}