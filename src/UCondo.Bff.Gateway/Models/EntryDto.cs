using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UCondo.Bff.Gateway.Models
{
    public class EntryDto
    {
        #region Entry

        public int Code { get; set; }
        public int SubCode { get; set; }
        public int ChildCode { get; set; }
        public string NameAccount { get; set; }
        //Receipt = 1
        //Expense = 2
        public int EntryType { get; set; }
        public bool AcceptEntry { get; set; }

        #endregion
    }
}