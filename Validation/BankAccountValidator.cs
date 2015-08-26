using FluentValidation;

namespace Validation
{
    public class BankAccountValidator : AbstractValidator<IBankAccount>
    {
        public BankAccountValidator()
        {
            RuleFor(account => account.AccountNumber).NotEmpty().Length(1, 40)
                .WithMessage("Account number is required and must be less than 40 characters.");

            RuleFor(account => account.BankAccountName).NotEmpty().Length(1, 254)
                .WithMessage("Bank Account Name is required and must be less than 254 characters.");
            
            RuleFor(account => account.ABA).Length(0, 20)
                .WithMessage("ABA should be less than 20 characters.");
            
            RuleFor(account => account.BankName).Length(0, 254)
                .WithMessage("Bank Name must be less than 254 characters.");
        }
    }
}
