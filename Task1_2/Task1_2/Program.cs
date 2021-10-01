using System;
using System.Collections.Generic;

namespace Task2_1
{
    class Program
    {
        private static void Task1()
        {
            var output_list = new List<uint>();

            for (uint i = 100; i <= 999; i++)
            {
                if (IsNonEqualDigits(i))
                    output_list.Add(i);
            }

            Console.WriteLine("Searched numbers:");

            foreach (var item in output_list)
                Console.WriteLine(item);
        }

        // Returns list of digits of passed numbers 
        private static List<uint> GetDigits(uint number)
        {
            string str = number.ToString();

            var result = new List<uint>();

            foreach (var letter in str)
            {
                result.Add(uint.Parse(letter.ToString()));
            }

            return result;
        }

        private static bool IsNonEqualDigits(uint number)
        {
            var numbers = GetDigits(number);

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                        return false;
                }
            }
            return true;
        }

        private static void Task2()
        {
            Console.WriteLine("Input your number:");

            uint num = uint.Parse(Console.ReadLine());

            if (IsEqualDigits(num))
                Console.WriteLine("Your number has equal numbers");
            else
                Console.WriteLine("Your number hasn't equal numbers");

        }

        // Return true if passed number has equal digits
        private static bool IsEqualDigits(uint number)
        {
            var numbers_arr = new List<uint>();

            while (number != 0)
            {
                numbers_arr.Add(number % 10);
                number /= 10;
            }

            foreach (var num in numbers_arr)
            {
                if (num != numbers_arr[0])
                    return false;
            }

            return true;
        }

        private static void Task3()
        {
            Console.WriteLine("Input n:");
            uint n = uint.Parse(Console.ReadLine());
            Console.WriteLine("Input m:");
            uint m = uint.Parse(Console.ReadLine());

            var num_list = new List<uint>();

            for (uint i = n; i > 0; i--)
            {
                if (Math.Pow(DigitsSum(i), 2) == m)
                    num_list.Add(i);
            }

            string output = "Searched numbers: ";

            foreach (var num in num_list)
                output += $"{num} ";

            Console.WriteLine(output);
        }

        // Returns sum of digits of passed number
        private static uint DigitsSum(uint number)
        {
            uint sum = 0;

            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        static void Main(string[] args)
        {
            Task1();
        }
    }
}
