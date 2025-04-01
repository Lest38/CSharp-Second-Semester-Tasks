using BankAccountHandler;
using System;

namespace CSharpTask2
{
    internal class Program
    {
        private BankAccount _account;
        private readonly BankAccountManager _accountManager;

        public Program()
        {
            _accountManager = new BankAccountManager();
            _account = _accountManager.InitializeAccount();
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1 - Deposit Money");
                Console.WriteLine("2 - Withdraw Money");
                Console.WriteLine("3 - Show Account Info");
                Console.WriteLine("4 - Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine() ?? string.Empty;
                ProcessUserChoice(choice);
            }
        }

        private void ProcessUserChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    DepositMoney();
                    break;

                case "2":
                    WithdrawMoney();
                    break;

                case "3":
                    DisplayAccountInfo();
                    break;

                case "4":
                    ExitProgram();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        private void DepositMoney()
        {
            Console.Write("Enter deposit amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount > 0)
            {
                _account.Deposit(depositAmount);
                Console.WriteLine($"Successfully deposited {depositAmount:C}");
            }
            else
            {
                Console.WriteLine("No deposit money");
            }
        }

        private void WithdrawMoney()
        {
            Console.Write("Enter withdrawal amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount) && withdrawAmount > 0)
            {
                try
                {
                    _account.Withdraw(withdrawAmount);
                    Console.WriteLine($"Withdrew {withdrawAmount:C}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No withdrawal money");
            }
        }

        private void DisplayAccountInfo()
        {
            Console.WriteLine("\n" + _account.GetAccountInfo());
        }

        private static void ExitProgram()
        {
            Console.WriteLine("Exiting the program. Goodbye!");
            Environment.Exit(0);
        }

        public static void Main()
        {
            Program program = new();
            program.Run();
        }
    }
}
