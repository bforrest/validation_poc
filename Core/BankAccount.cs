using System;
using System.Collections.Generic;
using Validation;

namespace Core
{
    public class BankAccount : IBankAccount //IValidatable<IBankAccount>,
    {
        public string AccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string ABA { get; set; }
        public string BankName { get; set; }

        //public bool Validate(IValidator<IBankAccount> validator, out IEnumerable<string> brokenRules)
        //{
        //    Console.WriteLine("CoreBankAccount:Validate");
        //    brokenRules = validator.BrokenRules();
        //    return validator.IsValid();
        //}
    }
}
