using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace Admin.ViewModels
{
    public class BankAccountViewModel: IBankAccount//, IValidatable<IBankAccount>
    {
        public string AccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string ABA { get; set; }
        public string BankName { get; set; }
    }
}
