using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private readonly List<string> _whitelist = new List<string> { "/api/public", "/api/Auth/login" };
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public JwtMiddleware(RequestDelegate next, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
    {
        _next = next;
        _configuration = configuration;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task Invoke(HttpContext context)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var logger = scope.ServiceProvider.GetRequiredService<IAppLogger<JwtMiddleware>>();

            // ... usa tu logger aquí ...
            logger.LogInformation("Validating token...");

            if (!_whitelist.Contains(context.Request.Path.Value!))
            {
                logger.LogInformation("No paso la white List...");
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                logger.LogInformation($"Token: {token}");
                if (token != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);

                    try
                    {
                        tokenHandler.ValidateToken(token, new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ClockSkew = TimeSpan.Zero
                        }, out SecurityToken validatedToken);
                    }
                    catch
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Invalid token");
                        return;
                    }
                }
            }
            logger.LogInformation("paso middleware...");

        }


        await _next(context);
    }
}