using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using UCondo.Core.Data;

namespace UCondo.Entries.Domain.Entries
{
    public interface IEntryRepository : IRepository<Entry>
    {
        Task<Entry> GetByCode(int code);
        Task<Entry> GetByCodeAndSubCode(int code, int subcode, bool accept);
        Task<Entry> GetLastByCodeAndSubCode(int code, int subcode, int childcode);
        void Add(Entry entry);
        void Update(Entry entry);

        DbConnection GetConnection();
    }
}