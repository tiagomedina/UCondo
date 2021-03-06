using System;
using UCondo.Core.Messages;

namespace UCondo.Entries.API.Application.Events
{
    public class EntryDoneEvent : Event
    {
        public int Code { get; private set; }

        public EntryDoneEvent(int code)
        {
            Code = code;
        }
    }
}