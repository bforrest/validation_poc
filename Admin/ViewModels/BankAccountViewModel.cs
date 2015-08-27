using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Validation;

namespace Admin.ViewModels
{
    public class BankAccountViewModel: IBankAccount, IValidatable<IBankAccount>
    {
        public string AccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string ABA { get; set; }
        public string BankName { get; set; }

        public bool Validate(AbstractValidator<IBankAccount> validator, IEnumerable<string> brokenRules)
        {
            var result = validator.Validate(this);
            brokenRules = result.Errors.Select(x => x.ErrorMessage);
            return result.IsValid;
        }
    }
}
