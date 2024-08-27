using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using TF_ClassRegistry.Data;
using TF_ClassRegistry.Helper;
using TF_ClassRegistry.Models;
using TF_ClassRegistry.Services;

namespace TF_ClassRegistry.Controllers;
public class AuthenController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAuthenService _authenService;
    private readonly ApiHelper _apiHelper;
    private readonly ILogger<HomeController> _logger;
    public AuthenController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IAuthenService authenService)
    {
        _httpContextAccessor = httpContextAccessor;
        _authenService = authenService;
        _logger = logger;
    }

    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        try
        {
            if(username.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }    

            var token = await _authenService.AuthenticateAndGetToken(username, password);

            if (!string.IsNullOrEmpty(token))
            {
                _httpContextAccessor.HttpContext.Session.SetString("AccessToken", token);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }
        catch
        {
            return RedirectToAction("Error", "Home");
        }

    }
}
