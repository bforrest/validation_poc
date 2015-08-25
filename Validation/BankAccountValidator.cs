using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Validation
{
    public class BankAccountValidator : IValidator<IBankAccount>
    {
        public BankAccountValidator(IBankAccount entity)
        {
            _entity = entity;
            validators = new List<Microsoft.Practices.EnterpriseLibrary.Validation.Validator>
            {
                new StringLengthValidator(0, RangeBoundaryType.Inclusive, 
                    20, RangeBoundaryType.Inclusive) //string.Format(String_Length_Message, "ABA"))
                    { Tag = entity.ABA},

                new StringLengthValidator(1, RangeBoundaryType.Inclusive, 
                    40, RangeBoundaryType.Inclusive) //, string.Format(String_Length_Message, "Account Number"))
                    { Tag = entity.AccountNumber},

                new StringLengthValidator(1, RangeBoundaryType.Inclusive, 
                    254, RangeBoundaryType.Inclusive) //, string.Format(String_Length_Message, "Bank Account Name"))
                    { Tag = entity.BankAccountName},

                new StringLengthValidator(0, RangeBoundaryType.Inclusive, 
                    254, RangeBoundaryType.Inclusive) //, string.Format(String_Length_Message, "Bank Name"))
                    { Tag = entity.BankName},
            };


        }

        public IEnumerable<string> BrokenRules()
        {
            Console.WriteLine("BankAccountValidator: BrokenRules");
            foreach (var validationResults in validators.Select(validator => validator.Validate(_entity)))
            {
                _brokenRules.AddRange(validationResults.Select(x => x.Message));
            }
            return _brokenRules;
        }

        public bool IsValid()
        {
            Console.WriteLine("BankAccountValidator:IsValid");
            return !BrokenRules().Any();
        }

        private readonly string String_Length_Message = "{0} must have an {1} between {4} and {5}";
        private readonly IBankAccount _entity;
        private readonly List<string> _brokenRules = new List<string>();
        private readonly List<Microsoft.Practices.EnterpriseLibrary.Validation.Validator> validators;
    }
}
