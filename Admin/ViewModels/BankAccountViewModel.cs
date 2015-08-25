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
        //public bool Validate(IValidator<IBankAccount> validator, out IEnumerable<string> brokenRules)
        //{
        //    Console.WriteLine("BankAccountViewModel:Validate");
        //    brokenRules = validator.BrokenRules();
        //    return validator.IsValid();
        //}
    }
}
