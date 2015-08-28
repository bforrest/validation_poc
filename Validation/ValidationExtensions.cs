using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Validation
{
    public static class ValidationExtensions
    {
        //public static bool ValidateBankAccount(this IBankAccount entity, out IEnumerable<string> brokenRules)
        //{
        //    var validator =new BankAccountValidator();
        //    var result = validator.Validate(entity);
        //    brokenRules = result.Errors.Select(x => x.ErrorMessage);
        //    return result.IsValid;
        //}

        public static bool ValidateBankAccount(this IBankAccount entity, out IEnumerable<Tuple<string, string>> brokenRules)
        {
            var validator = new BankAccountValidator();
            var result = validator.Validate(entity);
            
            brokenRules =
                result.Errors.Select(validationFailure => new Tuple<string, string>(validationFailure.PropertyName, validationFailure.ErrorMessage)).ToList();
            return result.IsValid;
        }
    }
}