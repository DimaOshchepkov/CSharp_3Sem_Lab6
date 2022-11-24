using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            while(true)
            {
                string[] str =  Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
                if(min > array[i])
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
            Array.Copy(arr, ind, newArr, ind+1, arr.Length - ind);
            newArr[ind] = elem;

            arr = newArr;
        }

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

        public static void Swap<T>(ref T x, ref T y)
        {
            T sup = x;
            x = y;
            y = sup;
        }

        public static void PrintArray(int[] array)
        {
            foreach (int i in array)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1) Поменять местами\n" +
                                "2) Пересечение\n" +
                                "3) Странный действия\n");
        }


    }

    enum task
    {
        swap = 1,
        intersection,
        strenge,
    }
}


