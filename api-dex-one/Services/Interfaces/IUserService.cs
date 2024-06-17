using Microsoft.Extensions.Logging;

public interface IUserService
{
    Task<IEnumerable<UserDtoAll>> GetAll();
    Task<UserDtoAll?> GetById(int id);
    Task<List<User>> GetUsersWithRolesAsync();
    Task<List<User>> GetUsersWithSpecificRoleAsync(string roleName);
    Task<bool> Update(UpdateUserDto updateUserDto);
    Task<bool> Delete(int id);
     Task<User> Add(CreateUserDto createUserDto);
}
