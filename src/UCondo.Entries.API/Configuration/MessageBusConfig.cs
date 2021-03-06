using UCondo.Core.Utils;
using UCondo.MessageBus;
using UCondo.Entries.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UCondo.Entries.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<EntryOrquestratorIntegrationHandler>()
                .AddHostedService<EntryIntegrationHandler>();
        }
    }
}