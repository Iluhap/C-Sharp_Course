using System;
using System.Collections.Generic;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task1();
            // Task2();
            // Task3();
            Task3();
        }

        /*
         * Из одномерного целочисленного массива переписать все числа во второй массив так,
         * чтобы сначала шли четные элементы, затем нули, потом нечетные элементы
         */
        private static void Task1()
        {
            Console.WriteLine("Input you array [into one line]:");
            string[] str_arr = Console.ReadLine().Trim().Split();

            var arr = new int[str_arr.Length];
            uint counter = 0;

            foreach (var number in str_arr)
                arr[counter++] = int.Parse(number);

            var result_arr = SortArr(ref arr);

            var output_str = "";
            foreach (var item in result_arr)
                output_str += item.ToString() + ' ';

            Console.WriteLine(output_str);

        }

        // Sorts array in order to task
        private static int[] SortArr(ref int[] arr)
        {
            var result_arr = new int[arr.Length];

            int[] odd_arr = new int[arr.Length];
            int[] even_arr = new int[arr.Length];
            int[] zeroes_arr = new int[arr.Length];

            int odd_index = 0;
            int even_index = 0;
            int zeroes_index = 0;

            foreach (var item in arr)
            {
                if (item != 0)
                {
                    if (item % 2 != 0)
                        odd_arr[odd_index++] = item;
                    else
                        even_arr[even_index++] = item;
                }
                else
                    zeroes_arr[zeroes_index++] = item;
            }

            Array.Resize<int>(ref odd_arr, odd_index);
            Array.Resize<int>(ref even_arr, even_index);
            Array.Resize<int>(ref zeroes_arr, zeroes_index);

            int result_counter = 0;

            foreach (var item in even_arr)
                result_arr[result_counter++] = item;

            foreach (var item in zeroes_arr)
                result_arr[result_counter++] = item;

            foreach (var item in odd_arr)
                result_arr[result_counter++] = item;


            return result_arr;
        }

        /*
         * Даны два неубывающих массива x и y. 
         * Найти их соединение, то есть неубывающий массив z, содержащий все их элементы, 
         * причем каждый элемент должен входить в массив z столько раз, сколько он входит в общей сложности в массивы x и y
         */
        private static void Task2()
        {
            int[] first, second;
            uint counter = 0;

            Console.WriteLine("Input first array [into one line]:");
            string[] first_str = Console.ReadLine().Trim().Split();

            Console.WriteLine("Input second array [into one line]:");
            string[] second_str = Console.ReadLine().Trim().Split();

            first = new int[first_str.Length];
            second = new int[second_str.Length];

            Array.Sort(first); Array.Reverse(first);
            Array.Sort(second); Array.Reverse(second);

            foreach (var item in first_str)
                first[counter++] = int.Parse(item.Trim());
            counter = 0;
            foreach (var item in second_str)
                second[counter++] = int.Parse(item.Trim());

            string output = "";
            foreach (var item in MergeArrays(first, second))
                output += item.ToString() + ' ';

            Console.WriteLine(output);
        }

        // Merge 2 arrays and returns result in first passed array
        private static int[] MergeArrays(in int[] first, in int[] second)
        {
            int[] result = new int[first.Length + second.Length];

            uint counter = 0;
            foreach (var item in first)
                result[counter++] = item;

            foreach (var item in second)
                result[counter++] = item;

            Array.Sort(result);

            return result;
        }

        /*
         * Дан текст (строка), содержащий в себе группы  букв, цифр, символов.
         * Преобразовать текст, отсортировав каждую группу букв по алфавиту,
         * каждую группу цифр в порядке убывания. Например: «cba1076 /’abfc3785,’’3946f»  - «abc7610 /’abcf8753,’’9643f» . 
         * Не использовать строковые функции
         */
        private static void Task3()
        {
            Console.WriteLine("Input your text:");
            string text = Console.ReadLine().Trim();

            text = SortString(text);

            Console.WriteLine(text);
        }

        static string SortString(string str)
        {
            str = SortCharGroups(str);
            str = SortDigitGroups(str);
            return str;
        }

        static string SortCharGroups(string str)
        {
            string acum = String.Empty;
            int right_edge = 0;


            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLetter(str[i]))
                {
                    acum += str[i];
                    right_edge = i;
                }
                else if (!Char.IsLetter(str[i]) || i == str.Length - 1)
                {
                    if (acum.Length != 0)
                    {
                        char[] acum_copy = acum.ToCharArray();
                        Array.Sort(acum_copy);

                        acum = new string(acum_copy);

                        char[] str_copy = str.ToCharArray();
                        acum.CopyTo(0, str_copy, i - acum.Length, acum.Length);
                        str = new String(str_copy);
                        acum = String.Empty;
                    }
                }
            }

            return str;
        }

        static string SortDigitGroups(string str)
        {
            string acum = String.Empty;
            int right_edge = 0;


            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]))
                {
                    acum += str[i];
                    right_edge = i;
                }
                else if (!Char.IsDigit(str[i]) || i == str.Length - 1)
                {
                    if (acum.Length != 0)
                    {
                        char[] acum_copy = acum.ToCharArray();
                        Array.Sort(acum_copy);
                        Array.Reverse(acum_copy);

                        acum = new string(acum_copy);

                        char[] str_copy = str.ToCharArray();
                        acum.CopyTo(0, str_copy, i - acum.Length, acum.Length);
                        str = new String(str_copy);
                        acum = String.Empty;
                    }
                }
            }

            return str;
        }

            /*
             * Характеристикой столбца целочисленной матрицы назовем сумму модулей его отрицательных нечетных элементов. 
             * Переставляя столбцы заданной матрицы, расположить их в соответствии с ростом характеристик. 
             * Найти сумму элементов в тех столбцах, которые содержат хотя бы один отрицательный элемент
             */
            private static void Task4()
        {
            uint row_number = 0;
            uint column_number = 0;

            Console.WriteLine("Input matrix size ( rows ):");
            row_number = uint.Parse(Console.ReadLine().Trim());

            Console.WriteLine("Input matrix size ( columns ):");
            column_number = uint.Parse(Console.ReadLine().Trim());

            var matrix = new int[column_number][];

            for (int i = 0; i < matrix.Length; i++)
                matrix[i] = new int[row_number];


            FillMatix(ref matrix);

            Console.WriteLine("Your matrix:");
            PrintMatrix(matrix);

            SortMatrix(ref matrix);

            Console.WriteLine("Sorted matrix:");
            PrintMatrix(matrix);

            var sum_array = new int[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                sum_array[i] = GetSumByCondition(ref matrix[i]);
            }

            string output = "Sum array: ";

            foreach (var item in sum_array)
            {
                output += item.ToString() + "\t";
            }

            Console.WriteLine(output);

        }

        // Fills matrix with random integers in [-100, 100]
        static void FillMatix(ref int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    var ran = new Random();
                    matrix[i][j] = ran.Next(-100, 100);
                }
            }
        }

        // Prints passed matrix to Console
        static void PrintMatrix(in int[][] matrix)
        {
            string output = "";

            int row_num = matrix[0].Length;
            int column_num = matrix.Length;

            for (int i = 0; i < row_num; i++)
            {
                string row = String.Empty;

                for (int j = 0; j < column_num; j++)
                    row += matrix[j][i].ToString() + '\t';

                output += $"|\t{row.Trim()}\t|\n";
            }

            Console.WriteLine(output);
        }

        // Delegate used to compare columns in Array.Sort function
        static int CompareColumns(int[] x, int[] y)
        {
            int x_sum = 0;
            int y_sum = 0;

            foreach (var item in x)
                if (item < 0 && Math.Abs(item) % 2 == 1)
                    x_sum += Math.Abs(item);


            foreach (var item in y)
                if (item < 0 && Math.Abs(item) % 2 == 1)
                    y_sum += Math.Abs(item);

            if (x_sum > y_sum)
            {
                return 1;
            }
            else if (x_sum < y_sum)
            {
                return -1;
            }
            else // When x_sum equals y_sum
            {
                return 0;
            }
        }

        // Sorts passed matrix
        static void SortMatrix(ref int[][] matrix)
        {
            Array.Sort<int[]>(matrix, CompareColumns);
        }

        // Returns sum of array elements in case of passing condition
        static int GetSumByCondition(ref int[] array)
        {
            int sum = 0;

            bool flag = false;

            foreach (var item in array)
            {
                if (item < 0)
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                foreach (var item in array)
                    sum += Math.Abs(item);

                return sum;
            }
            else
            {
                return 0;
            }
        }
    }
}
