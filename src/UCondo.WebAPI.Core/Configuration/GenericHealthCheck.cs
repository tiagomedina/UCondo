using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace UCondo.WebAPI.Core.Configuration
{
    public static class GenericHealthCheck
    {
        public static void AddGenericHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks();
        }

        public static void UseGenericHealthCheck(this WebApplication app, string path)
        {
            app.MapHealthChecks(path);
        }
    }
}
