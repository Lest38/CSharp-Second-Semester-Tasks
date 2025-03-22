namespace CSharpTask1
{
    internal static class Program
    {
        public static void Main()
        {
            ArrayClass array1 = new();
            array1.WriteArray();
            array1.ReadArray();
            int a = array1.FindZeroBetweenMinMax();

            ArrayClass array2 = new();
            array2.WriteArray();
            array2.ReadArray();
            int b = array2.FindZeroBetweenMinMax();

            ArrayClass array3 = new();
            array3.WriteArray();
            array3.ReadArray();
            int c = array3.FindZeroBetweenMinMax();
            ArrayClass.SolveFunction(a, b, c);

        }
    }
}
