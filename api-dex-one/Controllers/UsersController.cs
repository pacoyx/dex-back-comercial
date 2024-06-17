using System.Text.Json;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{    
    public ILogger<UsersController> _logger { get; }
    private IUserService _userService { get; }

    public UsersController(ILogger<UsersController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("Getting all users... =====================");
        var users = await _userService.GetAll();
        _logger.LogInformation("Users: {0}", JsonSerializer.Serialize(users));
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _logger.LogInformation("Getting user by id... =====================");
        var user = await _userService.GetById(id);
        if (user == null)
        {
            return NotFound();
        }
        _logger.LogInformation("User: {0}", JsonSerializer.Serialize(user));
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateUserDto createUserDto)
    {
        _logger.LogInformation("Adding user... =====================");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = await _userService.Add(createUserDto);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserDto updateUserDto)
    {
        _logger.LogInformation("Updating user... =====================");
        // validamos el modelo
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultUpdate = await _userService.Update(updateUserDto);
        if (!resultUpdate)
        {
            return NotFound();
        }
        return Ok("User updated successfully");

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _logger.LogInformation("Deleting user... =====================");
        var user = await _userService.Delete(id);
        if (!user)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("usersWithRoles")]
    public async Task<IActionResult> GetUsersWithRoles()
    {

        var settings = new Newtonsoft.Json.JsonSerializerSettings
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        };

        _logger.LogInformation("Getting users with roles... =====================");
        var users = await _userService.GetUsersWithRolesAsync();
        var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(users, settings);
        _logger.LogInformation("GetUsersWithRole: {0}", jsonString);
        IEnumerable<UserDtoWithRolesAll> usersDto = users.Select(user => user.AsDtoAllWithRoles());
        return Ok(usersDto);
    }

    [HttpGet("GetUsersWithSpecificRole")]
    public async Task<IActionResult> GetUsersWithSpecificRole(string roleName)
    {
        var settings = new Newtonsoft.Json.JsonSerializerSettings
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        };
        _logger.LogInformation("Getting users with specific role... =====================");
        var users = await _userService.GetUsersWithSpecificRoleAsync(roleName);
        var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(users, settings);
        _logger.LogInformation("GetUsersWithSpecificRole: {0}", jsonString);
        IEnumerable<UserDtoWithRolesAll> usersDto = users.Select(user => user.AsDtoAllWithRoles());
        return Ok(usersDto);
    }
}