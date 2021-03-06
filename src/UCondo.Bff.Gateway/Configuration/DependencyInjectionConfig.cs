using System;
using UCondo.Bff.Gateway.Extensions;
using UCondo.Bff.Gateway.Services;
using UCondo.WebAPI.Core.Extensions;
using UCondo.WebAPI.Core.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace UCondo.Bff.Gateway.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();



            services.AddHttpClient<IEntryService, EntryService>()
                .AllowSelfSignedCertificate()
                .AddPolicyHandler(PollyExtensions.EsperarTentar())
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        }
    }
}