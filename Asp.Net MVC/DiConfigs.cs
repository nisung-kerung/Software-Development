using Asp.Net_MVC.Data;
using Asp.Net_MVC.Repository;
using Asp.Net_MVC.Repository.Interface;
using Asp.Net_MVC.Services;
using Asp.Net_MVC.Services.Interface;

namespace Asp.Net_MVC;

public static class DiConfigs
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepo, UserRepo>();
        services.AddScoped<IUserService, UserService>();
        
        services.AddScoped<IRoleRepo, RoleRepo>();
        services.AddScoped<IUserRoleRepo, UserRoleRepo>();
    }
}