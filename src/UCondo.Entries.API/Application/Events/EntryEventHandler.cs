using System.Threading;
using System.Threading.Tasks;
using UCondo.Core.Messages.Integration;
using UCondo.MessageBus;
using MediatR;

namespace UCondo.Entries.API.Application.Events
{
    public class EntryEventHandler : INotificationHandler<EntryDoneEvent>
    {
        private readonly IMessageBus _bus;

        public EntryEventHandler(IMessageBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(EntryDoneEvent message, CancellationToken cancellationToken)
        {
            await _bus.PublishAsync(new EntryDoneIntegrationEvent(message.Code));
        }
    }
}