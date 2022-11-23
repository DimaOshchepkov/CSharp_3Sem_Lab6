using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyFunction.PrintMenu();
            Console.WriteLine("Введите задание");
            int numTask = MyFunction.ReadInt((int x) => x > 0, "Неверный ввод задания");
            switch(numTask)
            {
                case (int)task.swap:
                    {
                        int[] array = MyFunction.ReadIntInLine();
                        int indMin = MyFunction.IndexMin(array);
                        int indMax = MyFunction.IndexMax(array);

                        int middle = (int)Math.Ceiling((indMax + indMin) / 2.0);
                        for (int i = indMin; i < middle; i++)
                            MyFunction.Swap(ref array[i], ref array[indMax - i + indMin]);


                        MyFunction.PrintArray(array);
                        break;
                    }

                case (int)task.intersection:
                    {
                        int[] arr1 = { 1, 2, 3, 4, 5, 6 };
                        int[] arr2 = { 2, 4, 5, 6 };
                        int ind1 = 0;
                        int ind2 = 0;

                        int[] result = new int[Math.Max(arr1.Length, arr2.Length)];
                        int sizeIntersection = 0;
                        while(ind1 != arr1.Length && ind2 != arr2.Length)
                        {
                            if (arr1[ind1] == arr2[ind2])
                            {
                                result[sizeIntersection] = arr1[ind1];
                                sizeIntersection++;
                                ind1++;
                                ind2++;
                            }
                            else if (arr1[ind1] > arr2[ind2] && ind2 < arr2.Length)
                                ind2++;
                            else if (arr1[ind1] < arr2[ind2] && ind1 < arr1.Length)
                                ind1++;
                        }
                        Array.Resize(ref result, sizeIntersection);
                        MyFunction.PrintArray(result);
                        break;
                    }
            }

            Console.ReadKey();
        }
    }
}
