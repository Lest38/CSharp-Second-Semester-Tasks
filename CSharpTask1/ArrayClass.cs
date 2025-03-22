namespace CSharpTask1
{
    internal class ArrayClass
    {
        private int[] array = [];
        public int[] GetArray() { return array; }

        private static int GetValidInput(string prompt)
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

        public void WriteArray()
        {
            int arrayLength = GetValidInput("Введите длину массива: ");
            array = new int[arrayLength];
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GetValidInput($"Элемент {i + 1}: ");
            }
        }

        public void ReadArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        private (int, int) FindMinMax()
        {
            int min = int.MaxValue;
            int minIndex = 0;
            int max = int.MinValue;
            int maxIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    minIndex = i;
                }
                if (array[i] > max)
                {
                    max = array[i];
                    maxIndex = i;
                }
            }
            return (minIndex, maxIndex);
        }

        public int FindZeroBetweenMinMax()
        {
            (int minIndex, int maxIndex) = FindMinMax();
            int counter = 0;
            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (array[i] == 0)
                {
                    counter++;
                }
            }
            return counter;
        }

        public static void SolveFunction(int a, int b, int c)
        {
            if (a + b == 0)
            {
                throw new ArgumentException("Невозможно выполнить операцию с заданными значениями");
            }
            double result = (2 * Math.Sin(a) + 3 * b * Math.Pow(Math.Cos(c), 3)) / (a + b);
            Console.WriteLine(result);
        }
    }
}