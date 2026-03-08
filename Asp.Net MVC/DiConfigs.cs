using Asp.Net_MVC.Repository;
using Asp.Net_MVC.Repository.Interface;
using Asp.Net_MVC.Services;
using Asp.Net_MVC.Services.Interface;

namespace Asp.Net_MVC;

public static class DiConfigs
{
    public static void ConfigureServices(this IServiceCollection service)
    {
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IUserRepo, UserRepo>();
    }
}