using System;
using System.Runtime.InteropServices.ComTypes;

/* Лабораторная работа 6. Двумерные массивы */

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Задача 1. Дана целочисленная прямоугольная матрица. Определить:
             * количество строк, не содержащих ни одного нулевого элемента;
             * максимальное из чисел, встречающихся в заданной матрице более одного раза. 
            */
            Console.WriteLine("Введите кол-во строк m:");
            byte m = byte.Parse(Console.ReadLine());
            Console.WriteLine("Введите кол-во столбцов n:");
            byte n = byte.Parse(Console.ReadLine());
            short[,] matrix = new short[m, n];
            Random rnd = new Random();
            const int min = -10, max = 10;
            for (byte i = 0; i < m; ++i)
            {
                for (byte j = 0; j < n; ++j)
                {
                    matrix[i, j] = (short)rnd.Next(min, max);
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine();
            }

            bool notZiro;
            short notZiroCount = 0;
            for (byte i = 0; i < m; ++i)
            {
                notZiro = true;
                for (byte j = 0; j < n; ++j)
                {
                    if (matrix[i, j] == 0)
                    {
                        notZiro = false;
                        break;
                    }
                }

                if (notZiro)
                {
                    notZiroCount++;
                }
            }

            Console.WriteLine("В массиве {0} строк (-и) без элементов 0", notZiroCount);

            short maximum = min - 1, count;
            foreach (short i in matrix)
            {
                count = 0;
                foreach (short j in matrix)
                {
                    if (i == j)
                    {
                        count++;
                        if (count > 1) break;
                    }
                }

                if (count > 1 && i > maximum)
                {
                    maximum = i;
                }
            }

            if (maximum == min - 1)
            {
                Console.WriteLine("В матрице не оказалось повторяющихся чисел");
            }
            else
            {
                Console.WriteLine("{0} - наибольшее повторяющееся число в матрице", maximum);
            }


            /* Задача 2. Дана целочисленная прямоугольная матрица. Определить количество 
             * столбцов, не содержащих ни одного нулевого элемента. Характеристикой 
             * строки целочисленной матрицы назовем сумму ее положительных четных 
             * элементов. Переставляя строки заданной матрицы, расположить их в 
             * соответствии с ростом характеристик.
             */
            notZiroCount = 0;
            for (byte j = 0; j < n; ++j)
            {
                notZiro = true;
                for (byte i = 0; i < m; ++i)
                {
                    if (matrix[i, j] == 0)
                    {
                        notZiro = false;
                        break;
                    }
                }
                if (notZiro)
                {
                    notZiroCount++;
                }
            }
            Console.WriteLine("Количество столбцов без элемента 0 равно " + notZiroCount);

            int[] harakt = new int[m];
            byte[] indexes = new byte[m];
            int sum;
            short elem;
            for (byte i = 0; i < m; i++)
            {
                sum = 0;
                for (byte j = 0; j < n; j++)
                {
                    elem = matrix[i, j];
                    if (elem > 0 && elem % 2 == 0)
                    {
                        sum += elem;
                    }
                }
                harakt[i] = sum;
                indexes[i] = i;
            }

            // определим порядок индексов строк по увеличению характеристик
            // пузырьковая сортировка
            bool done;
            int tmp;
            do
            {
                done = false;
                for (byte i = 0; i < m - 1; i++)
                {
                    if (harakt[i] > harakt[i + 1])
                    {
                        tmp = harakt[i];
                        harakt[i] = harakt[i + 1];
                        harakt[i + 1] = tmp;
                        tmp = indexes[i];
                        indexes[i] = indexes[i + 1];
                        indexes[i + 1] = (byte)tmp;
                        done = true;
                    }
                }
            } while (done);

            // заполним новый массив строками в новом порядке
            short[,] newMatrix = new short[m, n];
            for (byte i = 0, k; i < m; i++)
            {
                k = indexes[i];
                for (byte j = 0; j < n; j++)
                {
                    newMatrix[i, j] = matrix[k, j];
                    Console.Write("\t" + newMatrix[i, j]);
                }
                Console.WriteLine("\tхарактеристика " + harakt[i]);
            }


            /*Задача 6. Дана целочисленная прямоугольная матрица. Определить:
             * сумму элементов в тех строках, которые содержат хотя бы один 
             * отрицательный элемент; номера строк и столбцов всех седловых точек 
             * матрицы. 
            */

            bool hasNegativeEl; // флаг равен true, если в строке есть отрицательные элементы
            for (byte i = 0; i < m; ++i)
            {
                sum = 0;
                hasNegativeEl = false;

                for (byte j = 0; j < n; ++j)
                {
                    sum += matrix[i, j];
                    if (matrix[i, j] < 0)
                    {
                        hasNegativeEl = true;
                    }
                }
                if (hasNegativeEl)
                {
                    Console.WriteLine("Строка {0} содержит отриц. элементы, сумма всех эл. равна {1}", i + 1, sum);
                }
            }


            short minInStr; // для хранения наименьшего значения в строке
            bool maxInCol; // для определения, является ли minInStr наибольшим в столбце
            for (byte i = 0; i < m; ++i)
            {
                minInStr = matrix[i, 0];

                for (byte j = 0; j < n; ++j)
                {   // ищем значение наименьшего элемента в строке
                    minInStr = minInStr > matrix[i, j] ? matrix[i, j] : minInStr;
                    /*if (minInStr > matrix[i, j])
                    {
                        minInStr = matrix[i, j];
                    }*/
                }

                // ищем количество нименьших элементов в строке, если их несколько
                for (byte j = 0; j < n; ++j)
                {
                    if (minInStr == matrix[i, j])
                    {
                        maxInCol = true;
                        // проверяем, является ли элемент седловым, просматривая элементы столбца
                        for (byte k = 0; k < m; ++k)
                        {
                            if (minInStr < matrix[k, j])
                            {
                                maxInCol = false;
                                break;
                            }
                        }
                        if (maxInCol)
                        {
                            Console.WriteLine("Найдена седловая точка! Строка {0}, солбец {1}, значение {2}", i + 1, j + 1, matrix[i, j]);
                        }
                    }
                }



            }

            /* 
             * Переписать задачи с использованием класса Matrix 
             */
            Matrix mt1 = new Matrix();
            Matrix mt2 = new Matrix(5, 6);
            Matrix mt3 = new Matrix(5, 6, -100, 100);
            Matrix mt4 = new Matrix(new short[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } });
            Matrix mt5 = new Matrix(new short[4, 5] { { -12, 3, 5, -17, 9 }, 
                                                      { -8, -7, 5, -8, 49 }, 
                                                      { -47, 0, 5, -10, 19 }, 
                                                      { -101, 3, 5, -42, 25 } });
            Matrix mt6 = new Matrix(new short[4, 5] { { -12, -23, 5, -17, 9 },
                                                      { -8, -27, 5, -8, 49 },
                                                      { -47, -100, 5, -10, 19 },
                                                      { -101, -23, 5, -42, 25 } });
            short[,] sedlo1 = mt4.GetSedloDigit();
            Console.WriteLine(mt4.SedloDigitString);
            short[,] sedlo2 = mt5.GetSedloDigit();
            Console.WriteLine(mt5.SedloDigitString);
            short[,] sedlo3 = mt6.GetSedloDigit();
            Console.WriteLine(mt6.SedloDigitString);




            /* Задача 9. Соседями элемента A{j в матрице назовем элементы Аы, где i-l<k<i+l ,
             * j - 1 < l<j + 1, (k, I) Операция сглаживания матрицы дает новую матрицу того 
             * же размера, каждый элемент которой получается как среднее арифметическое имеющихся
             * соседей соответствующего элемента исходной матрицы. Построить результат сглаживания 
             * заданной вещественной матрицы размером 10 х 10. В сглаженной матрице найти сумму модулей 
             * элементов, расположенных ниже главной диагонали. 
            */


            /* Задача 12. Уплотнить заданную матрицу, удаляя из нее строки и столбцы, заполненные нулями. 
             * Найти номер первой из строк, содержащих хотя бы один положительный элемент. 
            */


        }
    }
}
