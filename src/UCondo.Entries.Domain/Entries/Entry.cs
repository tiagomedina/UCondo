using System;
using System.Collections.Generic;
using System.Linq;
using UCondo.Core.DomainObjects;

namespace UCondo.Entries.Domain.Entries
{
    public class Entry : Entity, IAggregateRoot
    {
        public Entry(int code,
            int subcode, int childcode, string name, int entrytype, bool accept)
        {
            Code = code;
            SubCode = subcode;
            ChildCode = childcode;
            NameAccount = name;
            EntryType = entrytype;
            AcceptEntry = accept;
        }

        // EF ctor
        protected Entry() { }

        public int Code { get; set; }
        public int SubCode { get; set; }
        public int ChildCode { get; set; }
        public string NameAccount { get; set; }
        public int EntryType { get; set; }
        public bool AcceptEntry { get; set; }

        //public void Receipt()
        //{
        //    EntryType = EntryType.Receipt;
        //}
        //public void Expense()
        //{
        //    EntryType = EntryType.Expense;
        //}
    }
}