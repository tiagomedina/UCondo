using UCondo.Core.Messages;
using UCondo.Core.Messages.Integration;
using UCondo.MessageBus;
using UCondo.Entries.API.Application.DTO;
using UCondo.Entries.API.Application.Events;
using FluentValidation.Results;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UCondo.Entries.Domain.Entries;

namespace UCondo.Entries.API.Application.Commands
{
    public class EntryCommandHandler : CommandHandler,
        IRequestHandler<AddEntryCommand, ValidationResult>
    {
        private readonly IEntryRepository _entryRepository;

        public EntryCommandHandler(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task<ValidationResult> Handle(AddEntryCommand message, CancellationToken cancellationToken)
        {
            // command validation
            if (!message.IsValid()) return message.ValidationResult;

            // Map Entry
            var entry = MapEntry(message);

            // Validate entry
            if (!IsEntryValid(entry)) return ValidationResult;

            // Adding event
            entry.AddEvent(new EntryDoneEvent(entry.Code));

            // Add Entry Repositorio
            _entryRepository.Add(entry);

            // Commiting entry data
            return await PersistData(_entryRepository.UnitOfWork);
        }

        private Entry MapEntry(AddEntryCommand message)
        {
            var entry = new Entry(message.Code, message.SubCode, message.ChildCode, message.NameAccount, message.EntryType, message.AcceptEntry);
            return entry;
        }

        private bool IsEntryValid(Entry entry)
        {
            var entryFather = _entryRepository.GetByCode(entry.Code).GetAwaiter().GetResult();

            if (entryFather == null)
            {
                return true;
            }

            if (entryFather.Code != entry.Code)
            {
                AddError("The code is different");
                return false;
            }

            if (entryFather.Code != entry.Code && entryFather.AcceptEntry == true)
            {
                AddError("The account cannot have children");
                return false;
            }

            if (entryFather.EntryType != entry.EntryType)
            {
                AddError("Accounts are of different types");
                return false;
            }

            VerifySubcodeExist(entry);

            return true;
        }

        private bool VerifySubcodeExist(Entry entry)
        {
            var entrySubcode = _entryRepository.GetByCodeAndSubCode(entry.Code, entry.SubCode, entry.AcceptEntry).GetAwaiter().GetResult();

            if (entrySubcode == null && entry.AcceptEntry == false)
            {
                entry.SubCode = entrySubcode.SubCode + 1;
                return true;
            }
            else 
            {
                entrySubcode = _entryRepository.GetLastByCodeAndSubCode(entry.Code, entry.SubCode, entry.ChildCode).GetAwaiter().GetResult();

                if (entrySubcode != null && entry.SubCode != 0)
                {
                    entry.ChildCode = entrySubcode.ChildCode + 1;
                    return true;
                }

                if (entrySubcode != null && entry.SubCode == 0)
                {
                    entry.SubCode = entrySubcode.SubCode + 1;
                    return true;
                }
                else
                {
                    entry.SubCode++;
                    return true;
                }
            }
        }
    }
}