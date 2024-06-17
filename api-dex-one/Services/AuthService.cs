
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class AuthService : IAuthService
{
    public IUnitOfWork UnitOfWork { get; }
    public ILogger<AuthService> Logger { get; }
    private readonly IConfiguration _config;

    public AuthService(IUnitOfWork unitOfWork, ILogger<AuthService> logger, IConfiguration config)
    {
        _config = config;
        Logger = logger;
        UnitOfWork = unitOfWork;
    }
    public async Task<User?> IsValidUser(LoginModel login)
    {
        var userDb = await UnitOfWork.UsersPlus.GetByEmail(login.Email);
        if (userDb == null)
        {
            return null;
        }

        var passwordOk = Utils.VerifyPassword(login.Password, userDb!);
        if (userDb == null || !passwordOk)
        {
            return null;
        }
        return userDb;
    }

    public string BuildToken(User userDB)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "dex123bar"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userDB.Name),
                new Claim(JwtRegisteredClaimNames.Email, userDB.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userDB.RoleNameShort)
            };


        var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public void Dispose()
    {
        Logger.LogInformation("Disposing AuthService...");
    }
}