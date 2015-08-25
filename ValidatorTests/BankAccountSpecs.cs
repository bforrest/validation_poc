using System.Collections.Generic;
using Core;
using NUnit.Framework;
using Validation;

namespace ValidatorTests
{
    [TestFixture]
    public class BankAccountSpecs
    {
        [Test]
        public void has_validator()
        {
            var bankAccount = new BankAccount
            {
                ABA = "ASDF",
                BankAccountName = "ASDFASDF",
                AccountNumber = "ASDFASDFLKJ-",
                BankName = ""
            };

            IEnumerable<string> errors;

            BankAccountValidator val = new BankAccountValidator(bankAccount);
            //Validator.RegisterValidatorFor<IBankAccount>( new BankAccountValidator() );
            var isValid = val.IsValid();
            Assert.True(isValid);
        }
    }
}
