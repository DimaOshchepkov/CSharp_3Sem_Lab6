using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

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

                        Console.WriteLine("Минимальный " + indMin);
                        Console.WriteLine("Максимальный " + indMax);

                        int middle = (int)Math.Ceiling((indMax + indMin) / 2.0);
                        for (int i = Math.Min(indMin, indMax); i < middle; i++)
                            MyFunction.Swap(ref array[i], ref array[Math.Max(indMax, indMin) - i + Math.Min(indMin, indMax)]);


                        MyFunction.PrintArray(array);
                        break;
                    }

                case (int)task.intersection:
                    {
                        int[] arr1 = { 1, 2, 2, 3, 4, 5, 6 };
                        int[] arr2 = { 2, 2, 2, 4, 5, 6, 8 };
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
                case (int)task.snake:// вывод
                    {
                        Console.WriteLine("Введите количество рядов");
                        int row = MyFunction.ReadInt((int x) => x > 0, "Неверный ввод количества рядов");

                        Console.WriteLine("Введите количество столбцов");
                        int column = MyFunction.ReadInt((int x) => x > 0, "Неверный ввод количества столбцов");

                        int[,] arr = new int[row, column];
                        int step = 1;
                        bool downDirection = true;
                        int r = 0, c = 0;

                        while(step <= row*column)
                        {
                            arr[r, c] = step;

                            if (downDirection && c == 0 && r + 1 < row)
                            {
                                r++;
                                downDirection = false;
                            }
                            else if (!downDirection && r == 0 && c + 1 < column)
                            {
                                c++;
                                downDirection = true;
                            }
                            else if (downDirection)
                            {
                                if (r + 1 < row)
                                {
                                    r++;
                                    c--;
                                }
                                else
                                {
                                    c++;
                                    downDirection = false;
                                }
                            }
                            else if (!downDirection)
                            {
                                if (c + 1 < column)
                                {
                                    r--;
                                    c++;
                                }
                                else
                                {
                                    r++;
                                    downDirection=true;
                                }
                            }
                            Console.WriteLine();
                            step++;
                        }

                        MyFunction.PrintArray(arr);
                        Console.WriteLine();

                        for (int i = 1; i < arr.GetLength(0) - 1; i++)
                            for (int j = 1; j < arr.GetLength(1) - 1; j++)
                                if (arr[i, j] % 2 == 0)
                                    arr[i, j] = arr[i, j - 1] + arr[i, j + 1] + arr[i - 1, j] + arr[i + 1, j];

                        for (int j = 1; j < arr.GetLength(1) - 1; j++)
                        {
                            if (arr[0, j] % 2 == 0)
                                arr[0, j] = arr[0, j - 1] + arr[0, j + 1] + arr[0 + 1, j];
                            if (arr[row - 1, j] % 2 == 0)
                                arr[row-1, j] = arr[row-1, j - 1] + arr[row-1, j + 1] + arr[row - 2, j];
                        }

                        for (int j = 1; j < arr.GetLength(0) - 1;j++)
                        {
                            if (arr[j, 0] % 2 == 0)
                                arr[j, 0] = arr[j - 1, 0] + arr[j + 1, 0] + arr[j, 0 + 1];
                            if (arr[j, column - 1] % 2 == 0)
                                arr[j, column-1] = arr[j - 1, column-1] + arr[j + 1, column-1] + arr[j, column-2];
                        }

                        if (arr[row - 1, column - 1] % 2 == 0)
                            arr[row-1, column-1] = arr[row-1, column-2] + arr[row-2, column-1];
                        if (arr[0, 0] % 2 == 0)
                            arr[0, 0] = arr[1, 0] + arr[0, 1];
                        if (arr[0, column - 1] % 2 == 0)
                            arr[0, column - 1] = arr[1, column - 1] + arr[0, column - 2];
                        if (arr[row - 1, 0] % 2 == 0)
                            arr[row - 1, 0] = arr[row - 1, 1] + arr[row - 2, 0];

                        MyFunction.PrintArray(arr);
                        break;
                    }
                case (int)task.magicSquare: 
                    {
                        /*
                        int[,] arr = { { 2, 5, 6 },
                                        {9, 2, 3 },
                                        {5, 1, 5 }};*/
                        Console.WriteLine("Введите размер массива");
                        int size = MyFunction.ReadInt((int x) => x > 0, "Неверный ввод размера");

                        int[,] arr = new int[size, size];
                        MyFunction.FillArray(arr, -50, 150);

                        MyFunction.PrintArray(arr);

                        if (!MyFunction.IsMagicSquare(arr))
                        {
                            (int ind, int value)[] mins = new (int ind, int value)[arr.GetLength(1)];
                            for (int i = 0; i < arr.GetLength(1); i++)
                                mins[i] = (i, MyFunction.MinInColumn(arr, i));

                            Array.Sort(mins, new MyComp());

                            int[,] sortedArr = new int[arr.GetLength(0), arr.GetLength(1)];
                            for (int i = 0; i < sortedArr.GetLength(1); i++)
                                MyFunction.CopyColumn(arr, sortedArr, i, mins[i].ind);

                            MyFunction.PrintArray(sortedArr);
                        }
                        break;
                    }
                case (int)task.sumDigit:
                    {
                        //String str = "- 23l-j4l--32 k43hl 43l";
                        String str = Console.ReadLine();
                        String pattern = @"-?\d+";
                        Regex regex = new Regex(pattern);

                        MatchCollection matches = regex.Matches(str);

                        int sum = 0;
                        foreach (Match m in matches)
                            sum += int.Parse(m.Value);

                        Console.WriteLine("Сумма цифр равна " + sum);

                        break;
                    }

                case (int)task.findChars:
                    {
                        Console.WriteLine("Введите 1-ый сиимвол");
                        char s1 = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        Console.WriteLine("Введите 2-ый сиимвол");
                        char s2 = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        Console.WriteLine("Введите строку");
                        String str = Console.ReadLine();

                        if (MyFunction.CountSimbol(str, s1) == MyFunction.CountSimbol(str, s2))
                        {
                            Dictionary<char, int> dict = new Dictionary<char, int>();
                            foreach (var x in str)
                            {
                                if (!dict.ContainsKey(x))
                                    dict.Add(x, 1);
                                else
                                    dict[x]++;
                            }
                            MyFunction.PrintDict(dict);
                        }
                        break;
                    }
                case (int)task.split://виндовс форм
                    {
                        Console.WriteLine("Введите строку");
                        StringBuilder strBuild = new StringBuilder(Console.ReadLine());
                        
                        for(int i = 1; i < strBuild.Length; i++)
                        {
                            if (strBuild[i] != strBuild[i - 1])
                            {
                                strBuild.Insert(i, '*');
                                i++;
                            }
                        }
                        Console.WriteLine(strBuild.ToString());
                        

                        break;
                    }
                case (int)task.delGap:
                    {
                        Console.WriteLine("Введите строку");
                        ///9((ш)зд())9((()))9
                        String str = Console.ReadLine();

                        String pattern = @"\((\w+)\)";
                        String target = "";

                        Regex reg = new Regex(pattern);
                        str = Regex.Replace(str, pattern, String.Empty);

                        str = Regex.Replace(str, @"\(?\)?", String.Empty);
                        Console.WriteLine(str);

                        break;
                    }
                case (int)task.delSimbol:
                    {
                        
                        break;
                    }
                    
            }

            Console.ReadKey();
        }
    }
   
}
