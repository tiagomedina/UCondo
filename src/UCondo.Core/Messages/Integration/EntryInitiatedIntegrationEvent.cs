using System;

namespace UCondo.Core.Messages.Integration
{
    public class EntryInitiatedIntegrationEvent : IntegrationEvent
    {
        public int Code { get; set; }
        public int SubCode { get; set; }
        public int ChildCode { get; set; }
        public string NameAccount { get; set; }
        public int EntryType { get; set; }
        public bool AcceptEntry { get; set; }
    }
}