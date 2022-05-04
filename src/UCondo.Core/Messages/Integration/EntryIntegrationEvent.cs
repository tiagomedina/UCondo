using System;

namespace UCondo.Core.Messages.Integration
{
    public class EntryIntegrationEvent : IntegrationEvent
    {
        public int Code { get; private set; }

        public EntryIntegrationEvent(int code)
        {
            Code = code;
        }
    }
}