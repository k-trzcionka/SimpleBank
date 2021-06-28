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
            BankManager menu = new BankManager();
            menu.Run();

        }
    }
}
