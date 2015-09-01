using FluentValidation;

namespace Validation
{

    // No event storms when validating child objects.
    // Collection performance (adding each item to a collection)
    // Current is on by default unless disabled via "property"
    // ViewModel with child ViewModels vs Entity with Child entities
    // POC document for accounting
    public class BankAccountValidator : AbstractValidator<IBankAccount>
    {
        public BankAccountValidator()
        {
            RuleFor(account => account.AccountNumber).NotEmpty().Length(1, 40)
                .WithName("Account Number");

            RuleFor(account => account.BankAccountName).NotEmpty().Length(1, 254)
                .WithName("Bank Account Name");
            
            RuleFor(account => account.ABA).Length(0, 20)
                .WithMessage("ABA should be less than 20 characters.");
            
            RuleFor(account => account.BankName).Length(0, 254)
                .WithName("Bank Name");
        }
    }
}
