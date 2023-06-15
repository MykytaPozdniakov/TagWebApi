using System.Threading.Tasks;

public interface IAuthService
{
    Task<string> Login(string email, string password);
    Task<User> Register(string email, string password);
    Task<bool> UserExists(string email);
}