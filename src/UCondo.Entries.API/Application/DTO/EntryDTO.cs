using System;
using UCondo.Entries.Domain.Entries;

namespace UCondo.Entries.API.Application.DTO
{
    public class EntryDTO
    {
        public int Code { get; set; }
        public int SubCode { get; set; }
        public int ChildCode { get; set; }
        public string NameAccount { get; set; }
        public int EntryType { get; set; }
        public bool AcceptEntry { get; set; }

        public static EntryDTO ToEntryDTO(Entry entry)
        {
            var entryDTO = new EntryDTO
            {
                Code = (int)entry.Code,
                SubCode = (int)entry.SubCode,
                ChildCode = (int)entry.ChildCode,
                NameAccount = entry.NameAccount,
                EntryType = (int)entry.EntryType,
                AcceptEntry = entry.AcceptEntry
            };

            return entryDTO;
        }
    }
}