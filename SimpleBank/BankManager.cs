using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBank
{
    class BankManager
    {
        private AccountManager _accountManager;
        private IPrinter _printer;


        public BankManager()
        {
            _accountManager = new AccountManager();
            _printer = new PrintAccount();

        }

        private void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Lista kont klienta");
            Console.WriteLine("2 - Dodaj konto rozliczeniowe");
            Console.WriteLine("3 - Dodaj konto oszczędnościowe");
            Console.WriteLine("4 - Wpłać pieniądze na konto");
            Console.WriteLine("5 - Wypłać pieniądze z konta");
            Console.WriteLine("6 - Lista klientów");
            Console.WriteLine("7 - Wszystkie konta");
            Console.WriteLine("8 - Zakończ miesiąc");
            Console.WriteLine("0 - Zakończ");
        }

        private CustomerData ReadCustomerData()
        {
            string firstName;
            string lastName;
            string pesel;
            Console.WriteLine("Podaj dane klienta:");
            Console.Write("Imię: ");
            firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            pesel = Console.ReadLine();

            return new CustomerData(firstName, lastName, pesel);
        }
        private void ListOfAccounts()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Console.WriteLine();
            Console.WriteLine("Konta klienta {0} {1} {2}", data.FirstName, data.LastName, data.Pesel);

            foreach (Account account in _accountManager.GetAllAccountsFor(data.FirstName, data.LastName, data.Pesel))
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }

        private void AddBillingAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();

            Account billingAccount = _accountManager.CreateSavingsAccount(data.FirstName, data.LastName, data.Pesel);
            Console.WriteLine("Utworzono konto rozliczeniowe");
            _printer.Print(billingAccount);
            Console.ReadKey();
        }
        private void AddSavingsAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account savingsAccount = _accountManager.CreateSavingsAccount(data.FirstName, data.LastName, data.Pesel);
            Console.WriteLine("Utworzono konto oszczędnościowe");
            _printer.Print(savingsAccount);
            Console.ReadKey();
        }
        private int UserChoise()
        {
            Console.WriteLine("Wybór:");
            string choise = Console.ReadLine();
            if (string.IsNullOrEmpty(choise))
                {
                return -1;
                }
            return int.Parse(choise);
        }

        private void AddMoney()
        {
            string accountNo;
            decimal value;
            Console.Write("Podaj numer konta:");
            accountNo = Console.ReadLine();
            Console.Write("Podaj kwotę:");
            value = decimal.Parse(Console.ReadLine());
            _accountManager.Deposit(accountNo, value);
            Account account = _accountManager.GetAccount(accountNo);

            Console.ReadKey();
        }

        private void TakeMoney()
        {
            string accountNo;
            decimal value;
            Console.Write("Proszę podać numer konta z którego nalkeży dokonać wypłaty:");
            accountNo = Console.ReadLine();
            Console.Write("Proszę podać kwotę:");
            value = decimal.Parse(Console.ReadLine());
            _accountManager.Withdraw(accountNo,value);
            Account account = _accountManager.GetAccount(accountNo);
            Console.ReadKey();
        }
        private void ListOfCustomers()
        {
            Console.Clear();
            Console.WriteLine("Lista klientów:");
            foreach (string customer in _accountManager.ListOfCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.ReadKey();
        }
        private void ListOfAllAccounts()
        {
            Console.Clear();
            Console.WriteLine("Lista wszystkich kont:");
            foreach (Account account in _accountManager.GetAllAccounts())
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }
        private void CloseMonth()
        {
            Console.Clear();
            _accountManager.CloseMonth();
            Console.WriteLine("Miesiąc zamknięty");
            Console.ReadKey();
        }
        public void Run() {
            int choise;
            do
            {
                PrintMainMenu();
                choise = UserChoise();
                switch (choise)
                {
                    case 1:
                        ListOfAccounts();
                        break;
                    case 2:
                        AddBillingAccount();
                        break;
                    case 3:
                        AddSavingsAccount();
                        break;
                    case 4:
                        AddMoney();
                        break;
                    case 5:
                        TakeMoney();
                        break;
                    case 6:
                        ListOfCustomers();
                        break;
                    case 7:
                        ListOfAllAccounts();
                        break;
                    case 8:
                        CloseMonth();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Nieznane polecenie");
                        Console.ReadKey();
                        break;
                }
            
            } while (choise != 0);
}
    }
}
