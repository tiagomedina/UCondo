using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UCondo.Bff.Gateway.Extensions;
using UCondo.Bff.Gateway.Models;
using UCondo.Core.Communication;
using Microsoft.Extensions.Options;

namespace UCondo.Bff.Gateway.Services
{
    public interface IEntryService
    {
        Task<ResponseResult> AddEntry(EntryDto entry);
        Task<ResponseResult> UpdateEntry(EntryDto entry);
        Task<List<EntryDto>> GetAllEntries();

    }

    public class EntryService : Service, IEntryService
    {
        private readonly HttpClient _httpClient;

        public EntryService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.EntryUrl);
        }

        public async Task<ResponseResult> AddEntry(EntryDto entry)
        {
            var entryContent = GetContent(entry);

            var response = await _httpClient.PostAsync("/entries", entryContent);

            if (!ManageHttpResponse(response)) return await DeserializeResponse<ResponseResult>(response);

            return Ok();
        }

        public async Task<ResponseResult> UpdateEntry(EntryDto entry)
        {
            var entryContent = GetContent(entry);

            var response = await _httpClient.PutAsync("/entries", entryContent);

            if (!ManageHttpResponse(response)) return await DeserializeResponse<ResponseResult>(response);

            return Ok();
        }

        public async Task<List<EntryDto>> GetAllEntries()
        {
            var response = await _httpClient.GetAsync("/entries/all");

            if (response.StatusCode == HttpStatusCode.NotFound) return null;

            ManageHttpResponse(response);

            return await DeserializeResponse<List<EntryDto>>(response);
        }
    }
}