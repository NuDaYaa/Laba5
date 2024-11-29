using System;

namespace ArraySumOddPositions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array1 = GenerateRandomArray(10, 10);
            int[,] array2 = GenerateRandomArray(10, 10);

            Console.WriteLine("Первый массив:");
            PrintArray(array1);
            int count1 = CountRowsWithPositiveOddPositionSum(array1);

            Console.WriteLine("\nВторой массив:");
            PrintArray(array2);
            int count2 = CountRowsWithPositiveOddPositionSum(array2);

            if (count1 == 0) Console.WriteLine("\nНет строк с положительной суммой нечетных элементов в первом массиве.");
            else Console.WriteLine($"\nКоличество строк с положительной суммой нечетных элементов в первом массиве: {count1}");

            if (count2 == 0) Console.WriteLine("\nНет строк с положительной суммой нечетных элементов во втором массиве.");
            else Console.WriteLine($"\nКоличество строк с положительной суммой нечетных элементов во втором массиве: {count2}");
        }

        public static int[,] GenerateRandomArray(int rows, int cols)
        {
            int[,] array = new int[rows, cols];
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = rand.Next(-10, 11); // Генерация чисел в диапазоне от -10 до 10
                }
            }
            return array;
        }

        public static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static int CountRowsWithPositiveOddPositionSum(int[,] array)
        {
            int count = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int sum = CalculateOddPositionSum(array, i);
                if (sum > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public static int CalculateOddPositionSum(int[,] array, int row)
        {
            int sum = 0;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (j % 2 != 0) // Нечетные индексы (нечетные позиции)
                {
                    sum += array[row, j];
                }
            }
            return sum;
        }
    }
}