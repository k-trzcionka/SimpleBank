using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{
    class PrintAccount : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("\nDane konta:");
            Console.WriteLine($"Typ konta: {account.AccountType()}");
            Console.WriteLine($"Numer konta: {account.AccountNumber}");
            Console.WriteLine($"Saldo: {account.Balance}zł");
            Console.WriteLine($"Imię i nazwisko właściciela: {account.GetFullName()}");
            Console.WriteLine($"PESEL właściciela: {account.Pesel}");
        }
    }
}
