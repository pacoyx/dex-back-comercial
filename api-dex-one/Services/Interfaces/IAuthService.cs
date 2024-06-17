
public interface IAuthService : IDisposable
{
    Task<User?> IsValidUser(LoginModel login);
    string BuildToken(User userDB);
}
