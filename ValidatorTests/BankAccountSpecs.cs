using System;
using System.Collections.Generic;
using System.Linq;
using Admin.ViewModels;
using FluentValidation;
using NUnit.Framework;
using Validation;

namespace ValidatorTests
{
    [TestFixture]
    public class BankAccountSpecs
    {
        public class BankAccountSpecBase
        {
            [SetUp]
            public void SetUp()
            {
                // can replace this with the 
                // Admin.ViewModels.BankAccountViewModel
                // and the tests still pass.
                SUT = new Core.BankAccount
                {
                    BankAccountName = "ASDFASDF",
                    AccountNumber = "ASDFASDFLKJ-",
                };

                validator = new BankAccountValidator();
            }

            protected IBankAccount SUT;
            protected AbstractValidator<IBankAccount> validator;
        }

        public class MinimalValidBankAcount : BankAccountSpecBase
        {
            [Test]
            public void basica_valid_object()
            {
                var result = validator.Validate(SUT);
                Assert.True(result.IsValid);
            }
        }


        public class BankAccountNumberSpecs : BankAccountSpecBase
        {
            [Test]
            public void account_number_cannot_be_null()
            {
                SUT.AccountNumber = null;
                var result = validator.Validate(SUT);
                Assert.False(result.IsValid);
            }

            [Test]
            public void account_number_cannot_be_empty()
            {
                SUT.AccountNumber = string.Empty;
                var result = validator.Validate(SUT);
                Assert.False(result.IsValid);
            }

            [Test]
            public void account_number_less_than_40()
            {
                SUT.AccountNumber = SUT.AccountNumber.PadRight(41, '1');
                var result = validator.Validate(SUT);
                Assert.False(result.IsValid);
            }
        }

        public class BankAccount_BankAccountName : BankAccountSpecBase
        {
            [Test]
            public void bank_account_name_cannot_be_empty()
            {
                SUT.BankAccountName = string.Empty;
                var result = validator.Validate(SUT);
                Assert.False(result.IsValid);
                Console.WriteLine(result.Errors.First().ErrorMessage);
            }

            [Test]
            public void bank_account_name_cannot_be_null()
            {
                SUT.BankAccountName = null;
                var result = validator.Validate(SUT);
                Console.WriteLine(result.Errors.First().ErrorMessage);
                Assert.False(result.IsValid);
            }

            [Test]
            public void bank_account_must_be_less_than_254()
            {
                SUT.BankAccountName = SUT.BankAccountName.PadRight(255, '1');
                var result = validator.Validate(SUT);
                Assert.False(result.IsValid);
                var error = result.Errors.Where(x => x.PropertyName == "BankAccountName");
                Assert.NotNull(error);
                Console.WriteLine(error);
            }

            [Test]
            public void composed_validation_works()
            {
                SUT = new Admin.ViewModels.BankAccountViewModel
                {
                    BankAccountName = "ASDFASDF",
                    AccountNumber = "ASDFASDFLKJ-",
                };

                IEnumerable<string> brokenRules = new List<string>();
                var sut = (BankAccountViewModel) SUT;
                if (sut != null)
                {
                    Assert.True(sut.Validate(brokenRules));
                }
            }

            [Test]
            public void validate_via_extension_method()
            {
                IEnumerable<string> brokenRules = new List<string>();
                var result = SUT.ValidateBankAccount(out brokenRules);
                Assert.True(result);
                Assert.NotNull(brokenRules);
            }
        }
    }
}
