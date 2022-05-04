using System;
using System.Linq;
using System.Threading.Tasks;
using UCondo.Entries.Infra.Context;
using UCondo.WebAPI.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UCondo.Entries.API.Configuration
{

    public static class DbMigrationHelpers
    {
        /// <summary>
        /// Generate migrations before running this method, you can use command bellow:
        /// Nuget package manager: Add-Migration DbInit -context EntryContext
        /// Dotnet CLI: dotnet ef migrations add DbInit -c EntriesContext
        /// </summary>
        public static async Task EnsureSeedData(WebApplication app)
        {
            var services = app.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var ssoContext = scope.ServiceProvider.GetRequiredService<EntriesContext>();

            await DbHealthChecker.TestConnection(ssoContext);

            if (env.IsDevelopment() || env.IsEnvironment("Docker"))
                await ssoContext.Database.EnsureCreatedAsync();
        }

    }

}
