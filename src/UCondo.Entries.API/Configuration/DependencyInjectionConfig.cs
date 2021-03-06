using UCondo.Core.Mediator;
using UCondo.Entries.API.Application.Queries;
using UCondo.Entries.Domain.Entries;
using UCondo.Entries.Infra.Context;
using UCondo.Entries.Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace UCondo.Entries.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IEntryQueries, EntryQueries>();

            // Date
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<EntriesContext>();
        }
    }
}