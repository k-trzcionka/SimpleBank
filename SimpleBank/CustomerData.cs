using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBank
{
    class CustomerData
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long Pesel { get; }

        public CustomerData(string firstName, string lastName,string pesel)
        {
            FirstName  = firstName;
            LastName = lastName;
            Pesel = long.Parse(pesel);
        }
    }
}
