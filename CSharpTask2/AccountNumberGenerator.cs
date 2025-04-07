using System.Security.Cryptography;
using System.Text;

namespace BankAccountHandler
{
    internal class AccountNumberGenerator
    {
        /// <summary>
        /// Generates a random account number of the specified length.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static long GenerateAccountNumber(int length = 9)
        {
            if (length < 1 || length > 9)
                throw new ArgumentOutOfRangeException(nameof(length), "Account number length must be between 1 and 9 digits.");

            char[] digits = new char[length];
            for (int i = 0; i < length; i++)
            {
                digits[i] = (char)('0' + RandomNumberGenerator.GetInt32(0, 10));
            }
            return long.Parse(new string(digits));
        }
    }
}
