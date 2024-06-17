
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


[ApiController]
[Route("api/[controller]")]
public class RolController : ControllerBase
{
    private readonly IRolService _rolService;

    public IAppLogger<RolController> Logger { get; }

    public RolController(IRolService rolService, IAppLogger<RolController> logger)
    {
        _rolService = rolService;
        Logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Role>>> Get()
    {
        var roles = await _rolService.GetAll();
        var rolesDto = roles.Select(rol => rol.AsDtoAll());
        return Ok(rolesDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Role>> Get(int id)
    {
        var rol = await _rolService.GetById(id);
        if (rol == null)
        {
            return NotFound();
        }
        var rolDto = rol.AsDtoAll();
        return Ok(rolDto);
    }

    [HttpPost]
    public async Task<ActionResult<Role>> Create(CreateRoleDto rolDto)
    {
        Logger.LogInformation($"Creating new role {JsonSerializer.Serialize(rolDto)}");
        var rol = rolDto.AsRole();
        await _rolService.Create(rol);
        return CreatedAtAction(nameof(Get), new { id = rol.Id }, rol.AsDtoAll());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Role>> Update(int id, UpdateRoleDto rolDto)
    {
        var rol = rolDto.AsRole();
        var updatedRol = await _rolService.Update(id, rol);
        if (!updatedRol)
        {
            return NotFound();
        }
        return Ok(updatedRol);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _rolService.Delete(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
