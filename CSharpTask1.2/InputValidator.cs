using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTask1._2
{
    internal class InputValidator
    {
        public int GetValidInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
            }
        }
    }
}
