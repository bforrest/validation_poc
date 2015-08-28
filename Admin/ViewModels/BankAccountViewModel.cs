using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Validation;

namespace Admin.ViewModels
{
    public class BankAccountViewModel: IBankAccount, ICanValidate<IBankAccount>, INotifyPropertyChanged, IDataErrorInfo
    {
        public string AccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string ABA { get; set; }
        public string BankName { get; set; }

        public bool Validate(out IEnumerable<Tuple<string, string>> brokenRules)
        {
            return this.ValidateBankAccount(out brokenRules);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string this[string columnName]
        {
            get
            {
                this.ValidateBankAccount(out brokenRules);
                var q = brokenRules.AsQueryable().Where(x => x.Item1 == columnName);

                return string.Join(Environment.NewLine, q);
            }
        }

        public string Error
        {
            get
            {
                this.ValidateBankAccount(out brokenRules);
                var propertyNames = brokenRules as Tuple<string, string>[] ?? brokenRules.ToArray();
                var errs = string.Join(Environment.NewLine, propertyNames.Select(x => x.Item1));
                return errs;
            }
        }

        private IEnumerable<Tuple<string, string>> brokenRules;
    }
}
