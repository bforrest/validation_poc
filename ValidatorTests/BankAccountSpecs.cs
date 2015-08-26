using System;
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
                SUT = new BankAccountViewModel
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
        }
    }
}
