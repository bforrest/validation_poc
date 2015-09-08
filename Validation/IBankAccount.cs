namespace Validation
{
    public interface IBankAccount
    {
        string ABA { get; set; }

        string AccountNumber { get; set; }

        string BankAccountName { get; set; }
        
        string BankName { get; set; }

        string BIC { get; set; }

        string SortCode { get; set; }
    }
}
