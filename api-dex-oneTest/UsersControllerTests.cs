using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class UsersControllerTests
{
    private readonly UsersController _controller;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<ILogger<UsersController>> _loggerMock;
    private readonly Mock<IUserService> _userServiceMock;

    public UsersControllerTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _loggerMock = new Mock<ILogger<UsersController>>();
        _userServiceMock = new Mock<IUserService>();
        _controller = new UsersController(_unitOfWorkMock.Object, _loggerMock.Object, _userServiceMock.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkResultWithUsers()
    {
        // Arrange
        var users = new List<User>();
        _unitOfWorkMock.Setup(u => u.Users.GetAll()).ReturnsAsync(users);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var usersDto = Assert.IsAssignableFrom<IEnumerable<UserDtoAll>>(okResult.Value);
        Assert.Equal(users.Count, usersDto.Count());
    }

    [Fact]
    public async Task GetById_WithValidId_ReturnsOkResultWithUser()
    {
        // Arrange
        var user = new User { Id = 1 };
        _unitOfWorkMock.Setup(u => u.Users.GetById(It.IsAny<int>())).ReturnsAsync(user);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var userDto = Assert.IsType<UserDtoAll>(okResult.Value);
        Assert.Equal(user.Id, userDto.Id);
    }

    [Fact]
    public async Task GetById_WithInvalidId_ReturnsNotFoundResult()
    {
        // Arrange
        _unitOfWorkMock.Setup(u => u.Users.GetById(It.IsAny<int>())).ReturnsAsync((User)null);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    // Add tests for other controller methods...

}