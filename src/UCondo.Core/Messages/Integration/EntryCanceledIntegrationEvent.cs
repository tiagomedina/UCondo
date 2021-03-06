using System;

namespace UCondo.Core.Messages.Integration
{
    public class EntryCanceledIntegrationEvent : IntegrationEvent
    {
        public int Code { get; private set; }

        public EntryCanceledIntegrationEvent(int code)
        {
            Code = code;
        }
    }
}