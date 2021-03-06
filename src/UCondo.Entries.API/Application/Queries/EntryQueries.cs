using Dapper;
using UCondo.Entries.API.Application.DTO;
using UCondo.Entries.Domain.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCondo.Entries.API.Application.Queries
{
    public interface IEntryQueries
    {
        Task<List<EntryDTO>> GetAllEntries();
    }

    public class EntryQueries : IEntryQueries
    {
        private readonly IEntryRepository _entryRepository;

        public EntryQueries(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<List<EntryDTO>> GetAllEntries()
        {
            const string sql = @"SELECT * FROM ENTRIES ORDER BY CODE, SUBCODE, CHILDCODE";

            var entries = await _entryRepository.GetConnection().QueryAsync<EntryDTO>(sql);

            // get entries
            return entries.ToList();
        }

        private EntryDTO MapEntry(dynamic result)
        {
            var entry = new EntryDTO
            {
                Code = result[0].CODE,
                SubCode = result[0].SUBCODE,
                NameAccount = result[0].NAMEACCOUNT,
                EntryType = result[0].ENTRYTYPE,
                AcceptEntry = result[0].ACCEPTENTRY,
            };
            return entry;
        }
    }

}