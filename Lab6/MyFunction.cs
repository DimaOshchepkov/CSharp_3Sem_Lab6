using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal static class MyFunction
    {

        public static int ReadInt(Func<int, bool> lambda, String message = "Неверный ввод числа")
        {
            int num = -1;
            bool successRead = int.TryParse(Console.ReadLine(), out num) && lambda(num);
            while (!successRead)
            {
                Console.WriteLine(message);
                successRead = int.TryParse(Console.ReadLine(), out num) && lambda(num);
            }

            return num;
        }

        public static int[] ReadIntInLine(String message = "Неверный ввод чисел")
        {
            while (true)
            {
                string[] str = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] arr = new int[str.Length];
                int i = 0;
                while (i < arr.Length && int.TryParse(str[i], out arr[i])) i++;

                if (i == arr.Length)
                    return arr;
                else
                    Console.WriteLine(message);
            }
        }

        public static int[] ReadArray()
        {
            Console.WriteLine("Введите размер");
            int size = ReadInt((int x) => x > 0, "Неверный ввод массива");
            int[] array = new int[size];

            Console.WriteLine("Введите числа");
            for (int i = 0; i < size; i++)
                array[i] = ReadInt((int x) => true);

            return array;
        }

        public static int IndexMin(int[] array)
        {
            if (array.Length == 0)
                return -1;
            int min = array[0];
            int indMin = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                    indMin = i;
                }
            }
            return indMin;
        }

        public static int IndexMax(int[] array)
        {
            if (array.Length == 0)
                return -1;
            int max = array[0];
            int indMax = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                    indMax = i;
                }
            }
            return indMax;
        }

        public static void Insert(ref int[] arr, int ind, int elem)
        {
            int[] newArr = new int[arr.Length + 1];
            Array.Copy(arr, newArr, ind);
            Array.Copy(arr, ind, newArr, ind + 1, arr.Length - ind);
            newArr[ind] = elem;

            arr = newArr;
        }

        public static void Erase(ref int[] arr, int ind)
        {
            for (int i = ind + 1; i < arr.Length; i++)
                arr[i - 1] = arr[i];

            Array.Resize(ref arr, arr.Length - 1);
        }
        /*
        public static int[] Unique(int[] arr)
        {
            int[] sup = new int[arr.Length];
            Array.Copy(arr, sup, arr.Length);
            int countDel = 0;

            return 0;
        }
        */
        public static void Strange1(ref int[] arr)
        {
            int min = arr.Min();
            int max = arr.Max();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == max)
                {
                    Insert(ref arr, i, min);
                    i++;
                }
            }
        }

        public static void Strange2(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int j = i + 1;
                while (j < arr.Length)
                {
                    if (arr[j] == arr[i])
                        Erase(ref arr, j);
                    else
                        j++;
                }
            }
        }


        public static void Swap<T>(ref T x, ref T y)
        {
            T sup = x;
            x = y;
            y = sup;
        }

        public static void PrintArray(int[] array, int first = -1, int second = -1)
        {
            if (first == second && second == -1)
                foreach (int i in array)
                    Console.Write(i + " ");
            else if (first != -1 && second == -1)
                for (int i = first; i < array.Length; i++)
                    Console.Write(i + " ");
            else if (first == -1 && second != -1)
                for (int i = 0; i < second; i++)
                    Console.Write(i + " ");
            else if (first != -1 && second != -1)
                for (int i = first; i < second; i++)
                    Console.Write(i + " ");
        }

        public static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        public static int SumRowOfArr(int[,] arr, int ind)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(1); i++)
                sum += arr[ind, i];

            return sum;
        }

        public static int SumColumnOfArr(int[,] arr, int ind)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                sum += arr[i, ind];

            return sum;
        }

        public static int MinInColumn(int[,] arr, int ind)
        {
            int min = arr[0, ind];

            for (int i = 1; i < arr.GetLength(0); i++)
                if (min > arr[i, ind])
                    min = arr[i, ind];

            return min;
        }

        public static void SwapColumn(int[,] arr, int ind1, int ind2)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int sup = arr[i, ind1];
                arr[i, ind1] = arr[i, ind2];
                arr[i, ind2] = sup;
            }
        }

        public static void CopyColumn(int[,] arr1, int[,] arr2, int ind1, int ind2)
        {
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                arr2[i, ind2] = arr1[i, ind1];
            }
        }



        public static bool IsMagicSquare(int[,] arr)
        {
            int sum = SumRowOfArr(arr, 0);
            for (int i = 0; i < arr.GetLength(0); i++)
                if (sum != SumRowOfArr(arr, i) || sum != SumColumnOfArr(arr, i))
                    return false;

            int diag1 = 0;
            int diag2 = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                diag1 += arr[i, i];
                diag2 += arr[arr.GetLength(0) - 1 - i, i];
            }

            if (diag2 != sum || diag1 != sum)
                return false;


            return true;
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1) Поменять местами\n" +
                                "2) Пересечение\n" +
                                "3) Странный действия\n" +
                                "4) Змейка\n" +
                                "5) Магический квадрат\n");
        }


    }

    enum task
    {
        swap = 1,
        intersection,
        strenge,
        snake,
        magicSquare,
    }

    public class MyComp : IComparer<(int, int)>
    {
        public int Compare((int, int) x, (int, int) y)
        {
            return x.Item2.CompareTo(y.Item2);
        }
    }
}


