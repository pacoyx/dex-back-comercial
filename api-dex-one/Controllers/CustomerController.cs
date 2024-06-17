using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        var customers = await _customerService.GetAll();
        return Ok(new ApiResponse { Code = 100, Message = "Clientes encontrados", Data = customers.Select(eb => eb.AsSelectAllCustomerDto()) });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetById(int id)
    {
        var customer = await _customerService.GetById(id);
        if (customer == null)
        {
           return NotFound(new ApiResponse { Code = 99, Message = "Cliente no encontrado", Data = null });
        }
          return Ok(new ApiResponse { Code = 100, Message = "Cliente encontrado", Data = customer.AsSelectAllCustomerDto() });
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> Create(CreateCustomerDto customerDto)
    {
        var customer = customerDto.AsCustomer();
        await _customerService.Create(customer);
        return Ok(new ApiResponse { Code = 100, Message = "Cliente registrado", Data = customer.AsSelectAllCustomerDto() });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerDto customerDto)
    {
        if (id != customerDto.Id)
        {
            return BadRequest(new ApiResponse { Code = 99, Message = "Request incorrecto", Data = null });
        }

        var updated = await _customerService.Update(id, customerDto);
        if (!updated)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Cliente no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Cliente actualizado", Data = customerDto });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {                                                                                                                                                                                                               
        var deleted = await _customerService.Delete(id);
        if (!deleted)
        {
            return NotFound(new ApiResponse { Code = 99, Message = "Cliente no encontrado", Data = null });
        }
        return Ok(new ApiResponse { Code = 100, Message = "Cliente eliminado", Data = null });
    }
}