using System;

namespace Taks1_1
{
    class Program
    {
        static void Task1()
        {
            var number_count = 8;

            var arr = new double[number_count];

            Console.WriteLine($"Input numbers [{number_count}] ");

            for (int i = 0; i < number_count; i++)
            {
                arr[i] = double.Parse(Console.ReadLine());
            }

            var result_sum = 0.0;

            for (int i = 0; i < number_count; i++)
            {
                if (IsIntegerSqrt(arr[i]))
                    result_sum += arr[i];
            }

            Console.WriteLine($"Result sum: {result_sum}");
        }

        // Returns true when passed parameter has integer sqrt
        static bool IsIntegerSqrt(double number)
        {
            var tmp = Math.Sqrt(number);

            return tmp % 1 == 0;
        }

        // Implements Task 2
        static void Task2()
        {
            Console.WriteLine("Input N:");

            var num = int.Parse(Console.ReadLine());

            Console.WriteLine($"Sqrt sum: {SqrtSum(num)}");
        }

        // Returns sqrt sum
        static double SqrtSum(int number, int counter = 1)
        {
            if (counter.Equals(number))
                return Math.Sqrt(3 * number);

            return Math.Sqrt(3 * counter + SqrtSum(number, ++counter));
        }

        static void Main(string[] args)
        {
            Task1();
            // Task2();
        }
    }
}
