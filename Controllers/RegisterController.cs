using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TF_ClassRegistry.Data;
using TF_ClassRegistry.Models;

namespace TF_ClassRegistry.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public RegisterController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost]
    public async ValueTask<ResponseBase<RegistryReponse>> Add(RegistryRequest request)
    {
        try
        {
            var jwtToken = _httpContextAccessor.HttpContext.Session.GetString("AccessToken");
            var user = StaticData.Tokens.FirstOrDefault(x => x.Value == jwtToken);

            if (user.Key != null)
            {
                var listClasses = StaticData.Classes.TryGetValue(user.Key, out List<ClassInfo> cls) ? cls : null;
                if (listClasses != null)
                {
                    if (listClasses.Any(x => x.Id == request.Id))
                    {
                        listClasses.RemoveAll(x => x.Id == request.Id);
                    }
                    else
                    {
                        if (listClasses.Any(x => x.DayOfWeek == request.Date && x.Time == request.Time))
                        {
                            return new ResponseBase<RegistryReponse>
                            {
                                Code = "500",
                                Message = "Trùng cmnr!"
                            };
                        }
                        else if (request.Key == "MAIN-CLASS" && listClasses.Count(x => x.Key == "MAIN-CLASS") == 3)
                        {
                            return new ResponseBase<RegistryReponse>
                            {
                                Code = "500",
                                Message = "3 lớp main class thôi bé!"
                            };
                        }
                        else if (request.Key == "FREE-TALK" && listClasses.Count(x => x.Key == "FREE-TALK") == 1)
                        {
                            return new ResponseBase<RegistryReponse>
                            {
                                Code = "500",
                                Message = "1 lớp main class thôi bé!"
                            };
                        } 
                        else if (listClasses.Any(x => x.SyllabusId == request.SyllabusId))
                        {
                            return new ResponseBase<RegistryReponse>
                            {
                                Code = "500",
                                Message = "Trùng lớp cmnr!"
                            };
                        }
                        listClasses.Add(new ClassInfo
                        {
                            Id = request.Id,
                            Key = request.Key,
                            Time = request.Time,
                            DayOfWeek = request.Date,
                            SyllabusId = request.SyllabusId
                        });
                    }
                }
                else
                {
                    StaticData.Classes[user.Key] = new List<ClassInfo>
                    {
                        new ClassInfo
                        {
                             Id = request.Id,
                            Key = request.Key,
                            Time = request.Time,
                            DayOfWeek = request.Date,
                            SyllabusId = request.SyllabusId
                        }
                    };
                }

                return new ResponseBase<RegistryReponse>
                {
                    Code = "200",
                    Data = new RegistryReponse
                    {
                        Registried = StaticData.Classes[user.Key].Any(x => x.Id == request.Id),
                    }
                };
            }

            return default;

        }
        catch
        {
            throw;
        }
    }
}
