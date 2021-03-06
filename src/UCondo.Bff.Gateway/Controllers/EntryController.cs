using UCondo.Bff.Gateway.Models;
using UCondo.Bff.Gateway.Services;
using UCondo.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UCondo.Bff.Gateway.Controllers
{
    [Route("entries")]
    public class EntryController : MainController
    {
        private readonly IEntryService _entryService;

        public EntryController(
            IEntryService entryService)
        {
            _entryService = entryService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddEntry(EntryDto entry)
        {
            return CustomResponse(await _entryService.AddEntry(entry));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateEntry(EntryDto entry)
        {
            return CustomResponse(await _entryService.UpdateEntry(entry));
        }

        [HttpGet("all")]
        public async Task<IActionResult> AllEntries()
        {
            var entry = await _entryService.GetAllEntries();
            if (entry is null)
            {
                AddErrorToStack("Entry not found!");
                return CustomResponse();
            }

            return CustomResponse(entry);
        }
    }
}
