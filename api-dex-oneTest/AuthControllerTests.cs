using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class AuthControllerTests
{
    private readonly Mock<ILogger<UsersController>> _mockLogger;
    private readonly Mock<IAuthService> _mockAuthService;
    private readonly AuthController _controller;

    public AuthControllerTests()
    {
        _mockLogger = new Mock<ILogger<UsersController>>();
        _mockAuthService = new Mock<IAuthService>();
        _controller = new AuthController(_mockLogger.Object, _mockAuthService.Object);
    }

    [Fact]
    public async Task GenerateToken_ValidUser_ReturnsOkResult()
    {
        // Arrange
        var loginModel = new LoginModel { Email = "test@test.com", Password = "password" };
        var user = new User { Email = "test@test.com" };
        _mockAuthService.Setup(x => x.IsValidUser(loginModel)).ReturnsAsync(user);
        _mockAuthService.Setup(x => x.BuildToken(user)).Returns("token");

        // Act
        var result = await _controller.GenerateToken(loginModel);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Dictionary<string, string>>(okResult.Value);
        Assert.Equal("token", returnValue["token"]);
    }

    [Fact]
    public async Task GenerateToken_InvalidUser_ReturnsUnauthorizedResult()
    {
        // Arrange
        var loginModel = new LoginModel { Email = "test@test.com", Password = "password" };
        _mockAuthService.Setup(x => x.IsValidUser(loginModel)).ReturnsAsync((User)null);

        // Act
        var result = await _controller.GenerateToken(loginModel);

        // Assert
        Assert.IsType<UnauthorizedResult>(result);
    }
}