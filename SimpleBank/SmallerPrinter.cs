using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{
    class SmallerPrinter : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("\nDane konta:");
            Console.WriteLine($"Numer konta: {account.AccountNumber}");
            Console.WriteLine($"Imię i nazwisko właściciela: {account.GetFullName()}");
        }
    }
}
