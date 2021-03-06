using UCondo.Core.DomainObjects;
using UCondo.Core.Messages.Integration;
using UCondo.MessageBus;
using UCondo.Entries.Domain.Entries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UCondo.Entries.API.Services
{
    public class EntryIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public EntryIntegrationHandler(IServiceProvider serviceProvider, IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.SubscribeAsync<EntryCanceledIntegrationEvent>("EntryCanceled", CancelEntry);

            await _bus.SubscribeAsync<EntryIntegrationEvent>("EntryPaid", FinishEntry);
        }

        private async Task CancelEntry(EntryCanceledIntegrationEvent message)
        {
            using var scope = _serviceProvider.CreateScope();

            var entryRepository = scope.ServiceProvider.GetRequiredService<IEntryRepository>();

            var entry = await entryRepository.GetByCode(message.Code);
            //entry.Cancel();

            entryRepository.Update(entry);

            if (!await entryRepository.UnitOfWork.Commit())
            {
                throw new DomainException($"Problems while trying to cancel entry {message.Code}");
            }
        }

        private async Task FinishEntry(EntryIntegrationEvent message)
        {
            using var scope = _serviceProvider.CreateScope();

            var entryRepository = scope.ServiceProvider.GetRequiredService<IEntryRepository>();

            var entry = await entryRepository.GetByCode(message.Code);
            //entry.Finish();

            entryRepository.Update(entry);

            if (!await entryRepository.UnitOfWork.Commit())
            {
                throw new DomainException($"Problems found trying to finish o entry {message.Code}");
            }
        }
    }
}