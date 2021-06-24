using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{
    class BillingAccount : Account
    {

        public BillingAccount(int id, string firstName, string lastName, long pesel) :
            base(id, firstName, lastName, pesel)
        {

        }



        public void TakeCharge(decimal charge)
        {
            Balance -= charge; 
        }
        public override string AccountType()
        {
            return "Rozliczeniowe";
        }


    }
}
