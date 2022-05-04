using System;

namespace UCondo.Core.Messages.Integration
{
    public class EntryDoneIntegrationEvent : IntegrationEvent
    {
        public int Code { get; private set; }

        public EntryDoneIntegrationEvent(int code)
        {
            Code = code;
        }
    }
}