using BankAccountHandler;
using System;

namespace CSharpTask2
{
    internal class BankAccountManager
    {
        public BankAccount InitializeAccount()
        {
            Console.Write("Enter owner name: ");
            string ownerName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter initial balance: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal startingBalance) || startingBalance < 0)
            {
                Console.WriteLine("Invalid balance. Exiting program.");
                Environment.Exit(0);
            }

            BankAccount account = new BankAccount(ownerName, startingBalance);
            Console.WriteLine("\nAccount successfully created!");
            Console.WriteLine(account.GetAccountInfo());
            return account;
        }
    }
}
