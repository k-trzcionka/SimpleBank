using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{
     class AccountManager
    {
        private IList<Account> _accounts;

        public AccountManager()
        {
            _accounts = new List<Account>();
        }

        public SavingsAccount CreateSavingsAccount(string firstName, string lastName, long pesel)
        {
            int id = generateID();
            SavingsAccount account = new SavingsAccount(id, firstName, lastName, pesel);
            _accounts.Add(account);
            return account;
        }

        public BillingAccount CreateBillingAccount(string firstName, string lastName, long pesel)
        {
            int id = generateID();
            BillingAccount account = new BillingAccount(id, firstName, lastName, pesel);
            _accounts.Add(account);
            return account;
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }
        public int generateID()
        {
            int id = 1;

            if (_accounts.Any())
            {
                id = _accounts.Max(x => x.Id) + 1;
            }

            return id;
        }

        public IEnumerable<Account> GetAllAccountsFor(string firstName, string lastName, long pesel)
        {
            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.Pesel == pesel);
        }

        public Account GetAccount(string accountNo) 
        {
            return _accounts.Single(x => x.AccountNumber == accountNo);
        }

        public IEnumerable<string> ListOfCustomers()
        {
            return _accounts.Select(a => string.Format("Imię: {0} | Nazwisko: {1} | PESEL: {2}", a.FirstName, a.LastName, a.Pesel)).Distinct();
        }

        public void CloseMonth()
        {
            foreach (SavingsAccount account in _accounts.Where(x => x is SavingsAccount)) 
            { 
                account.AddInterest(0.04M);
            }
            foreach (BillingAccount account in _accounts.Where(x => x is BillingAccount))
            { 
                account.TakeCharge(5.0M); 
            }
        }
        public void Deposit(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(value);
        }

        public void Withdraw(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(-value);
        }
    }
}
