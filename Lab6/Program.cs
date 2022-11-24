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
                        Console.WriteLine("Введите массив");
                        int[] array = MyFunction.ReadIntInLine();
                        int indMin = MyFunction.IndexMin(array);
                        int indMax = MyFunction.IndexMax(array);

                        int middle = (int)Math.Ceiling((indMax + indMin) / 2.0);
                        for (int i = Math.Min(indMin, indMax); i < middle; i++)
                            MyFunction.Swap(ref array[i], ref array[Math.Max(indMax, indMin) - i + Math.Min(indMin, indMax)]);


                        MyFunction.PrintArray(array);
                        break;
                    }

                case (int)task.intersection:
                    {
                        int[] arr1 = { 1, 2, 3, 4, 5, 6 };
                        int[] arr2 = { 2, 4, 5, 6, 8 };
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

                        while (ind1 != arr1.Length)
                        {
                            if (arr1[ind1] == arr2.Last())
                            {
                                result[sizeIntersection] = arr2.Last();
                                sizeIntersection++;
                            }
                            ind1++;
                        }

                        while (ind2 != arr2.Length)
                        {
                            if (arr2[ind2] == arr1.Last())
                            {
                                result[sizeIntersection] = arr1.Last();
                                sizeIntersection++;
                            }
                            ind2++;
                        }

                        Array.Resize(ref result, sizeIntersection);
                        MyFunction.PrintArray(result);
                        break;
                    }
                case (int)task.strenge:
                    {
                        Console.WriteLine("Введите размер массива");
                        int size = MyFunction.ReadInt((int x) => x > 0, "Неверный ввод размера");

                        Random r = new Random();
                        int[] arr = new int[size];
                        for (int i = 0; i < arr.Length; i++)
                            arr[i] = r.Next(-15, 30 + 1);

                        int max = arr.Max();
                        int min = arr.Min();

                        Console.WriteLine("Максимальный элемент " + max);
                        Console.WriteLine("Минимальный элемент " + min);

                        //int[] test = { 1, 2, 3, 4, 4, 4, -1 };
                        MyFunction.PrintArray(arr);
                        MyFunction.Strange1(ref arr);
                        MyFunction.PrintArray(arr);
                        MyFunction.Strange2(ref arr);
                        MyFunction.PrintArray(arr);
                        break;
                    }
                    
                    
            }

            Console.ReadKey();
        }
    }
}
