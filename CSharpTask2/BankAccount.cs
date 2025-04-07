using System;

namespace BankAccountHandler
{
    internal class BankAccount
    {
        private readonly string _ownerName;
        private readonly long _accountNumber;
        private decimal _balance;

        public string OwnerName => _ownerName;
        public decimal Balance => _balance;

        /// <summary>
        /// Constructor for the BankAccount class.
        /// </summary>
        /// <param name="ownerName"></param>
        /// <param name="startingBalance"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public BankAccount(string ownerName, decimal startingBalance)
        {
            if (string.IsNullOrWhiteSpace(ownerName))
                throw new ArgumentException("Owner name cannot be empty.", nameof(ownerName));

            if (startingBalance < 0)
                throw new ArgumentOutOfRangeException(nameof(startingBalance), "Starting balance cannot be negative.");

            _ownerName = ownerName;
            _accountNumber = AccountNumberGenerator.GenerateAccountNumber();
            _balance = startingBalance;
        }

        /// <summary>
        /// Deposits a specified amount into the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be greater than zero.");

            _balance += amount;
        }

        /// <summary>
        /// Withdraws a specified amount from the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be greater than zero.");

            if (amount > _balance)
                throw new InvalidOperationException("Insufficient funds for withdrawal.");

            _balance -= amount;
        }

        /// <summary>
        /// Returns account information including owner name, balance, and account number.
        /// </summary>
        /// <returns></returns>
        public string GetAccountInfo()
        {
            return $"Account Owner: {_ownerName}, Balance: {_balance:C}, Account Number: {_accountNumber}";
        }
    }
}
