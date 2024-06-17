using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ExpenseBoxController : ControllerBase
{
    private readonly IExpenseBoxService _expenseBoxService;

    public ExpenseBoxController(IExpenseBoxService expenseBoxService)
    {
        _expenseBoxService = expenseBoxService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExpenseBoxes()
    {
        var expenseBoxes = await _expenseBoxService.GetAll();
        return Ok(new ApiResponse { Code = 100, Message = "Gastos encontrados", Data = expenseBoxes.Select(eb => eb.AsSelectAllExpenseBoxDto()) });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExpenseBoxById(int id)
    {
        var expenseBox = await _expenseBoxService.GetById(id);
        if (expenseBox == null)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Gasto no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Gasto encontrado", Data = expenseBox.AsSelectAllExpenseBoxDto() });
    }

    [HttpPost]
    public async Task<IActionResult> CreateExpenseBox(CreateExpenseBoxDto expenseBoxDto)
    {
        var expenseBox = expenseBoxDto.AsExpenseBox();
        await _expenseBoxService.Create(expenseBox);
        return Ok(new ApiResponse { Code = 100, Message = "Gasto registrado", Data = expenseBox.AsSelectAllExpenseBoxDto() });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExpenseBox(int id, UpdateExpenseBoxDto expenseBoxDto)
    {
        if (id != expenseBoxDto.Id)
        {
            return BadRequest(new ApiResponse { Code = 99, Message = "Request incorrecto", Data = null });
        }

        var expenseBox = expenseBoxDto.AsExpenseBox();
        var updated = await _expenseBoxService.Update(id, expenseBox);
        if (!updated)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Gasto no encontrada", Data = null });
        }

        return Ok(new ApiResponse { Code = 100, Message = "Gasto actualizado", Data = expenseBox.AsSelectAllExpenseBoxDto() });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpenseBox(int id)
    {
        var deleted = await _expenseBoxService.Delete(id);
        if (!deleted)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Gasto no encontrado", Data = null });
        }

        return Ok(new ApiResponse { Code = 100, Message = "Gasto eliminado", Data = null });
    }
}
