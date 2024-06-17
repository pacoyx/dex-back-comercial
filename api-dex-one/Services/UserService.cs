
public class UserService : IUserService
{
    public IUnitOfWork UnitOfWork { get; }

    public UserService(IUnitOfWork unitOfWork)
    {        
        UnitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserDtoAll>> GetAll(){
        var users = await UnitOfWork.Users.GetAll();
        IEnumerable<UserDtoAll> usersDto = users.Select(user => user.AsDtoAll());
        return usersDto;
    }

    public async Task<UserDtoAll?> GetById(int id)
    {
        var user = await UnitOfWork.Users.GetById(id);
        if (user == null)
        {
            return null;
        }
        return user.AsDtoAll();
    }

    public async Task<User> Add(CreateUserDto createUserDto)
    {
        var saltPwd = Utils.GenerateSalt();
        createUserDto.PasswordHash = Utils.HashPassword(createUserDto.PasswordHash, saltPwd);
        var user = createUserDto.AsUser();
        user.Salt = saltPwd;
        await UnitOfWork.Users.Create(user);
        UnitOfWork.Complete();
        return user;
    }

    public async Task<bool> Update(UpdateUserDto updateUserDto)
    {
        var userDb = await UnitOfWork.Users.GetById(updateUserDto.Id);
        if (userDb == null)
        {
            return false;
        }

        var user = updateUserDto.AsUser();
        user.FechaRegistro = userDb.FechaRegistro;
        user.EstadoLogico = userDb.EstadoLogico;
        user.FechaRegistro = userDb.FechaRegistro;

        UnitOfWork.Users.Update(user);
        UnitOfWork.Complete();
        return true;
    }
    
    public async Task<bool> Delete(int id){
        var user = await UnitOfWork.Users.GetById(id);
        if (user == null)
        {
            return false;
        }
        UnitOfWork.Users.Delete(user);
        UnitOfWork.Complete();
        return true;
    }

    public async Task<List<User>> GetUsersWithRolesAsync()
    {
        return await UnitOfWork.UsersPlus.GetUsersWithRolesAsync();
    }

    public async Task<List<User>> GetUsersWithSpecificRoleAsync(string roleName)
    {
        return await UnitOfWork.UsersPlus.GetUsersWithSpecificRoleAsync(roleName);
    }

  
}