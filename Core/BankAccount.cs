﻿using System;
using System.Collections.Generic;
using Validation;

namespace Core
{
    public class BankAccount : IBankAccount, ICanValidate<IBankAccount>
    {
        public string AccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string ABA { get; set; }
        public string BankName { get; set; }
        public string BIC { get; set; }
        public string SortCode { get; set; }

        public bool Validate(out IEnumerable<Tuple<string, string>> brokenRules)
        {
           return this.ValidateBankAccount(out brokenRules);
        }
    }
}
