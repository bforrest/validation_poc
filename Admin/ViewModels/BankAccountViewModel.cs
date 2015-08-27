using System.Collections.Generic;
using Validation;

namespace Admin.ViewModels
{
    public class BankAccountViewModel: IBankAccount, IValidatable<IBankAccount>
    {
        public string AccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string ABA { get; set; }
        public string BankName { get; set; }
        public bool Validate(IEnumerable<string> brokenRules)
        {
            return this.ValidateBankAccount(out brokenRules);
        }
    }
}
