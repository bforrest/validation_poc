using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Admin.Models;
using Validation;

namespace Admin.ViewModels
{
    public class BankAccountViewModel : IBankAccount, ICanValidate<IBankAccount>, INotifyPropertyChanged, IDataErrorInfo
    {
        public BankAccountViewModel()
        {
            var data = new ObservableCollection<IBankAccount>();

            for (int i = 0; i < 10000; i++)
            {
                var account = string.Format("Account {0}", i);
                var aba = string.Format("ABA {0}", i);
                var bic = string.Format("BIC {0}", i);
                var sort = string.Format("Sort Code {0}", i);
                var name = string.Format("Bank {0}", i);
                var bankName = string.Format("Bank Name {0}", i);

                data.Add(
                    new BankAccount
                    {
                        ABA = aba,
                        AccountNumber = account,
                        BIC = bic,
                        BankAccountName = name,
                        BankName = bankName,
                        SortCode = sort
                    });
            }

            _banks = new ListCollectionView(data);
            _banks.CurrentChanged += _banks_CurrentChanged;
            //_banks.CurrentChanging += _banks_CurrentChanging;

        }

        private void _banks_CurrentChanging(object sender, CurrentChangingEventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine(e);
        }

        private void _banks_CurrentChanged(object sender, EventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine("Current = {0}", _banks.CurrentItem);
            var item = _banks.CurrentItem;
            if (item != null)
            {
                _banks.MoveCurrentTo(item);
            }
            
            //_banks.MoveCurrentTo()
        }

        public string AccountNumber { get; set; }
        public string BankAccountName { get; set; }
        public string ABA { get; set; }
        public string BankName { get; set; }
        public string BIC { get; set; }
        public string SortCode { get; set; }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (_searchString == value) return;

                _searchString = value;
               PropertyChanged(this,new PropertyChangedEventArgs("SearchString"));

                if (String.IsNullOrEmpty(value))
                    _banks.Filter = null;
                else
                    _banks.Filter = new Predicate<object>(o => ((BankAccount)o).ABA == value || ((BankAccount)o).BIC == value);
            }
        }

        public IBankAccount Selected
        {
            get{ return _banks.CurrentItem as BankAccount; }
        }

        public ICollectionView Banks
        {
            get { return _banks; }
        }

        public bool Validate(out IEnumerable<Tuple<string, string>> brokenRules)
        {
            return this.ValidateBankAccount(out brokenRules);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string this[string columnName]
        {
            get
            {
                this.ValidateBankAccount(out _brokenRules);
                var q = _brokenRules.AsQueryable().Where(x => x.Item1 == columnName);

                return string.Join(Environment.NewLine, q);
            }
        }

        public string Error
        {
            get
            {
                this.ValidateBankAccount(out _brokenRules);
                var propertyNames = _brokenRules as Tuple<string, string>[] ?? _brokenRules.ToArray();
                var errs = string.Join(Environment.NewLine, propertyNames.Select(x => x.Item1));
                return errs;
            }
        }

        private IEnumerable<Tuple<string, string>> _brokenRules;

        private readonly ListCollectionView _banks;

        private string _searchString = string.Empty;
    }
}
