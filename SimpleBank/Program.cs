using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank
{
    class Program
    {
        static void Main(string[] args)
        {
            string welcome = "Witaj w prostej bankowości elektronicznej!";
            string author = "Klaudiusz Trzcionka";
            Console.WriteLine($"{welcome}\nAutor: {author}\n\n");

            //Tworzenie listy kont
            AccountManager manager = new AccountManager();

            manager.CreateBillingAccount("Klaudiusz", "Trzcionka", 94071914441);
            manager.CreateBillingAccount("Andrzej", "Podpisze", 90170924541);
            manager.CreateBillingAccount("Jan", "Kowalski", 89071914441);
            manager.CreateSavingsAccount("Klaudiusz", "Trzcionka", 94071914441);
            manager.CreateSavingsAccount("Andrzej", "Podpisze", 90170924541);
            manager.CreateSavingsAccount("Jan", "Kowalski", 89071914441);



            IList<Account> accounts = (IList<Account>)manager.GetAllAccounts();

            PrintAccount printer = new PrintAccount();

            foreach (Account account in accounts)
            {
                printer.Print(account);

            }

            IEnumerable<string> customers = manager.ListOfCustomers();

            foreach (string customer in customers)
            {
                Console.WriteLine(customer);

            }

            BankManager menu = new BankManager();
            menu.Run();

        }
    }
}
