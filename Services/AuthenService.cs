
using TF_ClassRegistry.Data;
using TF_ClassRegistry.Helper;
using TF_ClassRegistry.Models;

namespace TF_ClassRegistry.Services;

public class AuthenService : IAuthenService
{
    private readonly ILogger<AuthenService> _logger;
    private readonly ApiHelper _apiHelper;

    public AuthenService(ILogger<AuthenService> logger, ApiHelper apiHelper)
    {
        _logger = logger;
        _apiHelper = apiHelper;
    }

    public async ValueTask<string> AuthenticateAndGetToken(string username, string password, bool isSave = true)
    {
        try
        {
            var url = "https://service.talkfirst.vn/v1/api/account/student/login";
            var response = await _apiHelper.PostAsync<ResponseBase<TokenResponse>>(url, new { username, password });
            if (response != null && response?.Code == "200")
            {
                if (isSave)
                {
                    StaticData.Users[username] = password;
                    StaticData.Tokens[username] = response?.Data.Token;
                }

                return response?.Data.Token;
            }
            return default;
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            throw;
        }
    }
}
