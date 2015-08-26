﻿using System;
using System.Collections.Generic;
using Validation;

namespace Core
{
    public class BankAccount : IBankAccount
    {
        public string AccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string ABA { get; set; }
        public string BankName { get; set; }

        public BankAccount() { }
    }
}
