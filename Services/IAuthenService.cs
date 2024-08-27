namespace TF_ClassRegistry.Services;

public interface IAuthenService
{
    public ValueTask<string> AuthenticateAndGetToken(string username, string password, bool isSave = true);
}
