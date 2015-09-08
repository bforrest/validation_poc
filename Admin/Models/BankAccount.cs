using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Admin.Models
{
    public class BankAccount: IBankAccount
    {
        public string ABA { get; set; }
        public string AccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string BankName { get; set; }
        public string BIC { get; set; }
        public string SortCode { get; set; }
    }
}
