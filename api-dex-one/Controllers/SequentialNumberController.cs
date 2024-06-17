using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SequentialNumberController : ControllerBase
{
    private readonly ISequentialNumberService _sequentialNumber;

    public SequentialNumberController(ISequentialNumberService sequentialNumber)
    {
        _sequentialNumber = sequentialNumber;
    }

    [HttpGet]
    public async Task<IActionResult> GetNextSequentialNumber()
    {
        var correlativos = await _sequentialNumber.GetAll();
        return Ok(new ApiResponse { Code = 100, Message = "Clientes encontrados", Data = correlativos.Select(eb => eb.AsSelectAllSequentialNumberDto()) });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSequentialNumberById(int id)
    {
        var sequentialNumber = await _sequentialNumber.GetById(id);
        if (sequentialNumber == null)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "COrrelativo no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Correlativo encontrado", Data = sequentialNumber.AsSelectAllSequentialNumberDto() });
    }

    [HttpPost]
    public IActionResult CreateSequentialNumber(CreateSequentialNumberDto createSequentialNumberDto)
    {
        var sequentialNumber = createSequentialNumberDto.AsSequentialNumber();
        _sequentialNumber.Create(sequentialNumber);
        return Ok(new ApiResponse { Code = 100, Message = "Correlativo registrado", Data = sequentialNumber.AsSelectAllSequentialNumberDto() });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSequentialNumber(int id, UpdateSequentialNumberDto updateSequentialNumberDto)
    {
        if (id != updateSequentialNumberDto.Id)
        {
            return BadRequest(new ApiResponse { Code = 99, Message = "Request incorrecto", Data = null });
        }

        var result = await _sequentialNumber.Update(id, updateSequentialNumberDto);
        if (!result)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Correlativo no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Correlativo actualizado", Data = updateSequentialNumberDto });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSequentialNumber(int id)
    {
        var deleted = await _sequentialNumber.Delete(id);
        if (!deleted)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Correlativo no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Correlativo eliminado", Data = null });
    }
}
