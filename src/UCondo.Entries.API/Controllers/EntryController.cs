using UCondo.Core.Mediator;
using UCondo.Entries.API.Application.Commands;
using UCondo.Entries.API.Application.Queries;
using UCondo.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace UCondo.Entries.API.Controllers
{
    [Route("entries")]
    public class EntryController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IEntryQueries _entryQueries;

        public EntryController(IMediatorHandler mediator,
            IEntryQueries entryQueries)
        {
            _mediator = mediator;
            _entryQueries = entryQueries;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddEntry(AddEntryCommand entry)
        {
            return CustomResponse(await _mediator.SendCommand(entry));
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateEntry(UpdateEntryCommand entry)
        {
            return CustomResponse(await _mediator.SendCommand(entry));
        }

        [HttpGet("all")]
        public async Task<IActionResult> AllEntries()
        {

            var entries = await _entryQueries.GetAllEntries();

            return entries == null ? NotFound() : CustomResponse(entries);
        }
    }
}