using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace UCondo.Entries.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "UCondo Entries API",
                    Description = "Esta API faz parte do Hands On da UCondo.",
                    Contact = new OpenApiContact() {Name = "Tiago Medina", Email = "tiago.medina@outlook.com"},
                    License = new OpenApiLicense() {Name = "MIT", Url = new Uri("https://opensource.org/Licenses/MIT")}
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}