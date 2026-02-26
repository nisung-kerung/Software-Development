using Asp.Net_MVC.Providers;
using Asp.Net_MVC.Services;
using Asp.Net_MVC.Services.Interface;

namespace Asp.Net_MVC
{
    public static class DiConfig
    {
        public static void UseDbContext(this WebApplicationBuilder builder)
        {
            ConnectionProvider.Initialize(builder.Configuration);
            builder.Services.AddScoped<IUserService, UserService>();
        }
    }
}