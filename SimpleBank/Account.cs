using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{
    abstract class Account
    {
        public int Id { get; }
        public string AccountNumber { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public decimal Balance { get; set; }
        public long Pesel { get; }

        public Account(int id, string firstName, string lastName, long pesel)
        {
            Id = id;
            AccountNumber = generateAccountNumber(id);
            Balance = 0.0M;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
        }
        public string GetFullName()
        {
            string fullName = string.Format($"{FirstName} {LastName}");
            return fullName;
        }
        public string GetBalance()
        {
            string balance = $"Obecny stan konta to {Balance}zł";
            return balance;

        }

        private string generateAccountNumber(int id)
        {
            var accountNumber = string.Format("94{0:D10}", id);
            return accountNumber;
        }
        public abstract string AccountType();

        public Account()
        {

        }
        public void ChangeBalance(decimal value)
        {
            
            Balance += value;
        }
    }
}
