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
                Sut = new Core.BankAccount
                {
                    BankAccountName = "ASDFASDF",
                    AccountNumber = "ASDFASDFLKJ-",
                };

                Validator = new BankAccountValidator();
            }

            protected IBankAccount Sut;
            protected AbstractValidator<IBankAccount> Validator;
        }

        public class MinimalValidBankAcount : BankAccountSpecBase
        {
            [Test]
            public void basica_valid_object()
            {
                var result = Validator.Validate(Sut);
                Assert.True(result.IsValid);
            }
        }


        public class BankAccountNumberSpecs : BankAccountSpecBase
        {
            [Test]
            public void account_number_cannot_be_null()
            {
                Sut.AccountNumber = null;
                var result = Validator.Validate(Sut);
                Assert.False(result.IsValid);
            }

            [Test]
            public void account_number_cannot_be_empty()
            {
                Sut.AccountNumber = string.Empty;
                var result = Validator.Validate(Sut);
                Assert.False(result.IsValid);
            }

            [Test]
            public void account_number_less_than_40()
            {
                Sut.AccountNumber = Sut.AccountNumber.PadRight(41, '1');
                var result = Validator.Validate(Sut);
                Assert.False(result.IsValid);
            }
        }

        public class BankAccountNameSpecs : BankAccountSpecBase
        {
            [Test]
            public void bank_account_name_cannot_be_empty()
            {
                Sut.BankAccountName = string.Empty;
                var result = Validator.Validate(Sut);
                Assert.False(result.IsValid);
                Console.WriteLine(result.Errors.First().ErrorMessage);
            }

            [Test]
            public void bank_account_name_cannot_be_null()
            {
                Sut.BankAccountName = null;
                var result = Validator.Validate(Sut);
                Console.WriteLine(result.Errors.First().ErrorMessage);
                Assert.False(result.IsValid);
            }

            [Test]
            public void bank_account_must_be_less_than_254()
            {
                Sut.BankAccountName = Sut.BankAccountName.PadRight(255, '1');
                var result = Validator.Validate(Sut);
                Assert.False(result.IsValid);
                var error = result.Errors.Where(x => x.PropertyName == "BankAccountName");
                Assert.NotNull(error);
                Console.WriteLine(error);
            }

            [Test]
            public void composed_validation_works()
            {
                Sut = new BankAccountViewModel
                {
                    BankAccountName = "ASDFASDF",
                    AccountNumber = "ASDFASDFLKJ-",
                };

                var sut = (BankAccountViewModel) Sut;
                if (sut == null) return;

                IEnumerable<string> brokenRules;
                Assert.True(sut.Validate(out brokenRules));
            }

            [Test]
            public void validate_via_extension_method()
            {
                IEnumerable<string> brokenRules;
                var result = Sut.ValidateBankAccount(out brokenRules);
                Assert.True(result);
                Assert.NotNull(brokenRules);
            }
        }
    }
}
