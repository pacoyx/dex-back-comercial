

using System.Text.Json;

public class RolService : IRolService
{
    public IUnitOfWork UnitOfWork { get; }
    public ILogger<RolService> Logger { get; }

    public RolService(IUnitOfWork unitOfWork, ILogger<RolService> logger)
    {
        Logger = logger;
        UnitOfWork = unitOfWork;
    }

    public async Task Create(Role rol)
    {
        await UnitOfWork.Roles.Create(rol);
        UnitOfWork.Complete();
    }

    public async Task<Role?> GetById(int id)
    {
        return await UnitOfWork.Roles.GetById(id);
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        return await UnitOfWork.Roles.GetAll();
    }

    public async Task<bool> Update(int rolId, Role role)
    {
        var rolDb = await UnitOfWork.Roles.GetById(rolId);
        if (rolDb == null)
        {
            return false;
        }
        role.Id = rolId;
        UnitOfWork.Roles.Update(role);
        UnitOfWork.Complete();
        Logger.LogInformation($"Rol {role.Id} updated {0}",JsonSerializer.Serialize(role));
        return true;
    }

    public async Task<bool> Delete(int rolId)
    {
        var rolDb = await UnitOfWork.Roles.GetById(rolId);
        if (rolDb == null)
        {
            return false;
        }
        UnitOfWork.Roles.Delete(rolDb);
        UnitOfWork.Complete();
        return true;
    }
}