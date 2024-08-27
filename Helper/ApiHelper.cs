using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace TF_ClassRegistry.Helper;

public class ApiHelper
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ApiHelper(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async ValueTask<T> GetAsync<T>(string url, bool token = true)
    {
        if (token)
        {
            var accessToken = _httpContextAccessor.HttpContext.Session.GetString("AccessToken");

            if (string.IsNullOrEmpty(accessToken))
            {
                throw new InvalidOperationException("Access token is not available.");
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
        var response = await _httpClient.GetAsync(url);
        _ = response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return content.Deserialize<T>();
    }

    public async ValueTask<T> PostAsync<T>(string url, object data, bool token = false, string authToken = "")
    {
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

        if (token)
        {
            var accessToken = authToken.IsNullOrEmpty() ? _httpContextAccessor.HttpContext.Session.GetString("AccessToken") : authToken;
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new InvalidOperationException("Access token is not available.");
            }
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
        }

        var response = await _httpClient.PostAsync(url, content);
        //_ = response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();

        return responseContent.Deserialize<T>();
    }

}