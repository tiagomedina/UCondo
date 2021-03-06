using UCondo.Core.Messages.Integration;
using UCondo.MessageBus;
using UCondo.Entries.API.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UCondo.Entries.API.Services
{
    public class EntryOrquestratorIntegrationHandler : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EntryOrquestratorIntegrationHandler> _logger;
        private Timer _timer;

        public EntryOrquestratorIntegrationHandler(ILogger<EntryOrquestratorIntegrationHandler> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Entry service initialized.");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Entry service finished.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}