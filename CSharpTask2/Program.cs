using BankAccountHandler;
using System;

namespace CSharpTask2
{
    internal class Program
    {
        private BankAccount _account;
        private readonly BankAccountManager _accountManager;

        /// <summary>
        /// Constructor for the Program class.
        /// </summary>
        public Program()
        {
            _accountManager = new BankAccountManager();
            _account = _accountManager.InitializeAccount();
        }

        /// <summary>
        /// Main loop of the program that displays options to the user and processes their input.
        /// </summary>
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

        /// <summary>
        /// Processes the user's choice based on the input.
        /// </summary>
        /// <param name="choice"></param>
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

        /// <summary>
        /// Prompts the user to enter a deposit amount and processes the deposit.
        /// </summary>
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

        /// <summary>
        /// Prompts the user to enter a withdrawal amount and processes the withdrawal.
        /// </summary>
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

        /// <summary>
        /// Displays the account information including owner name and balance.
        /// </summary>
        private void DisplayAccountInfo()
        {
            Console.WriteLine("\n" + _account.GetAccountInfo());
        }

        /// <summary>
        /// Exits the program with a goodbye message.
        /// </summary>
        private static void ExitProgram()
        {
            Console.WriteLine("Exiting the program. Goodbye!");
            Environment.Exit(0);
        }

        /// <summary>
        /// Main method that serves as the entry point for the program.
        /// </summary>
        public static void Main()
        {
            Program program = new();
            program.Run();
        }
    }
}
