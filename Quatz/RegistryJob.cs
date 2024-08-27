using Quartz;
using TF_ClassRegistry.Data;
using TF_ClassRegistry.Helper;
using TF_ClassRegistry.Models;
using TF_ClassRegistry.Services;

namespace TF_ClassRegistry.Quatz;

public class RegistryJob : IJob
{
    private readonly ILogger<RegistryJob> _logger;
    private readonly IAuthenService _authenService;
    private readonly ApiHelper _apiHelper;

    public RegistryJob(ILogger<RegistryJob> logger, IAuthenService authenService, ApiHelper apiHelper)
    {
        _logger = logger;
        _authenService = authenService;
        _apiHelper = apiHelper;
    }

    public async Task Execute(IJobExecutionContext context)
    {

        StaticData.RegistryResults.Clear();

        foreach (var user in StaticData.Users)
        {
            var token = await _authenService.AuthenticateAndGetToken(user.Key, user.Value, false);

            var r = new List<RegistryResult>();
            foreach (var cl in StaticData.Classes[user.Key])
            {
                _logger.LogInformation("[Job] Registry the class {id}", cl.Id);

                var response = await _apiHelper.PostAsync<ResponseBase<dynamic>>("https://service.talkfirst.vn/v1/api/student/lesson/register", new { lessonId = cl.Id }, true, token);

                r.Add(new RegistryResult
                {
                    ClassInfo = cl,
                    Response = response
                });

                _logger.LogInformation("[Job] Response : {r}", response.Serialize());

                StaticData.RegistryResults[user.Key] = r;
            }
        }

        StaticData.Classes.Clear();

        _logger.LogInformation("[Job] Hello, Quartz.NET!");
    }
}
