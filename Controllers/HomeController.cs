using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TF_ClassRegistry.Data;
using TF_ClassRegistry.Helper;
using TF_ClassRegistry.Models;

namespace TF_ClassRegistry.Controllers;
public class HomeController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ApiHelper _apiHelper;
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, ApiHelper apiHelper)
    {
        _httpContextAccessor = httpContextAccessor;
        _apiHelper = apiHelper;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("AccessToken")))
        {
            return Redirect("Authen");
        }
        //var url = "https://service.talkfirst.vn/v1/api/student/lesson/current-week?";
        var url = "https://service.talkfirst.vn/v1/api/student/lesson/next-week?";
        var response = await _apiHelper.GetAsync<ResponseBase<List<ClassModel>>>(url);

        var jwtToken = _httpContextAccessor.HttpContext.Session.GetString("AccessToken");
        var user = StaticData.Tokens.FirstOrDefault(x => x.Value == jwtToken);
        var listClasses = StaticData.Classes.TryGetValue(user.Key, out List<ClassInfo> cls) ? cls : null;
        if (listClasses != null)
        {
            foreach (var item in response.Data)
            {
                item.IsRegistried = listClasses != null && listClasses.Any(x => x.Id == item.Id);
            }
        }

        return View(response.Data);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
