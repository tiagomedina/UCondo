using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using UCondo.Core.Data;
using UCondo.Entries.Domain.Entries;
using UCondo.Entries.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace UCondo.Entries.Infra.Repository
{
    public class EntryRepository : IEntryRepository
    {
        private readonly EntriesContext _context;

        public EntryRepository(EntriesContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public DbConnection GetConnection() => _context.Database.GetDbConnection();

        public async Task<Entry> GetByCode(int code)
        {
            return await _context.Entries
                .FirstOrDefaultAsync(p => p.Code == code && p.AcceptEntry == false);
        }

        public async Task<Entry> GetByCodeAndSubCode(int code, int subcode, bool accept)
        {
            return await _context.Entries
                .FirstOrDefaultAsync(p => p.Code == code && p.SubCode == subcode && p.AcceptEntry == accept);
        }

        public async Task<Entry> GetLastByCodeAndSubCode(int code, int subcode, int childcode)
        {
            return await _context.Entries
                .OrderByDescending(p => p.Code == code && p.SubCode == subcode && p.ChildCode == childcode)
                .FirstOrDefaultAsync(p => p.Code == code && p.SubCode == subcode && p.ChildCode == childcode);
        }

        public void Add(Entry entry)
        {
            _context.Entries.Add(entry);
        }

        public void Update(Entry entry)
        {
            _context.Entries.Update(entry);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}