public interface IAppLogger<T>
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message);
    // ... otros métodos de registro que necesites ...
}