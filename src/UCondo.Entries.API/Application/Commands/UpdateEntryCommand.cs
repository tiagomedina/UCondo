using System;
using System.Collections.Generic;
using UCondo.Core.Messages;
using UCondo.Entries.API.Application.DTO;
using FluentValidation;

namespace UCondo.Entries.API.Application.Commands
{
    public class UpdateEntryCommand : Command
    {
        // Entry
        public int Code { get; set; }
        public int SubCode { get; set; }
        public int ChildCode { get; set; }
        public string NameAccount { get; set; }
        public int EntryType { get; set; }
        public bool AcceptEntry { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateEntryValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateEntryValidation : AbstractValidator<UpdateEntryCommand>
        {
            public UpdateEntryValidation()
            {
                RuleFor(c => c.Code)
                    .NotEqual(0)
                    .WithMessage("Invalid Code");

                RuleFor(c => c.EntryType)
                    .GreaterThan(0)
                    .WithMessage("Invalid entry EntryType");

            }
        }
    }
}