using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    public ILogger<UsersController> Logger { get; }
    public IAuthService AuthService { get; }

    public AuthController(ILogger<UsersController> logger, IAuthService authService)
    {
        Logger = logger;
        AuthService = authService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> GenerateToken([FromBody] LoginModel login)
    {
        Logger.LogInformation("Generating token... =====================");
        var userOK = await AuthService.IsValidUser(login);
        if (userOK != null)
        {
            var tokenString = AuthService.BuildToken(userOK);
            var settings = new Newtonsoft.Json.JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            Logger.LogInformation("User autorizado {0}", Newtonsoft.Json.JsonConvert.SerializeObject(userOK, settings));
            return Ok(new { user = userOK.AsDtoLogin(), token = tokenString });
        }
        Logger.LogInformation("User No autorizado... {0}", login.Email);
        return Unauthorized();
    }
}
