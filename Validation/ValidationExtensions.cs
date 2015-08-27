using System.Collections.Generic;
using System.Linq;

namespace Validation
{
    public static class ValidationExtensions
    {
        public static bool ValidateBankAccount(this IBankAccount entity, out IEnumerable<string> brokenRules)
        {
            var validator =new BankAccountValidator();
            var result = validator.Validate(entity);
            brokenRules = result.Errors.Select(x => x.ErrorMessage);
            return result.IsValid;
        }
    }
}