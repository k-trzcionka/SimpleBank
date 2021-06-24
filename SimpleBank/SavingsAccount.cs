using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{
    class SavingsAccount : Account
    {


        public void AddInterest(decimal interest)
        {
            Balance += Balance*interest;
        }

        public SavingsAccount(int id, string firstName, string lastName, long pesel) :
            base(id, firstName, lastName, pesel)
        {

        }

        public override string AccountType()
        {
            return "Oszczędnościowe";
        }

    }
}
