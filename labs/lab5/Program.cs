using System;

/* Лабораторная работа 5. Одномерные массивы  */

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Задача 5. В одномерном массиве, состоящем из п вещественных элементов, 
             * вычислить: максимальный элемент массива; сумму элементов массива, 
             * расположенных до последнего положительного элемента. Сжать массив, 
             * удалив из него все элементы, модуль которых находится в интервале [а, Ь]. 
             * Освободившиеся в конце массива элементы заполнить нулями. 
            */

            Console.WriteLine("Введите n");
            int n = Int32.Parse(Console.ReadLine()), k = -1;
            float[] mas = new float[n], masTmp = new float[n];
            float sum = 0, max;

            Random rnd = new Random();

            for (int i = 0; i < n; ++i)
            {
                mas[i] = (float)rnd.NextDouble() * 200 - 100;
            }

            ShowMas(mas);
            //Array.Copy(mas, masTmp, n);

            max = mas[0];
            foreach (float i in mas)
            {
                max = i > max ? i : max;
            }

            Console.WriteLine("Максимальный элемент массива равен {0}", max);

            for (int i = n - 1; i >= 0; --i)
            {
                if (mas[i] > 0)
                {
                    k = i;
                    break;
                }
            }

            if (k == -1)
            {
                Console.WriteLine("В массиве нет положительных элементов");
                return;
            }
            else
            {
                Console.WriteLine("В массиве последний положительный элемент равен {0}, его индекс {1}.", mas[k], k);
            }

            for (int i = 0; i < k; i++)
            {
                sum += mas[i];
            }

            Console.WriteLine("Сумма элементов массива, расположенных до последнего положительного элемента равна " + sum);
            //Array.Sort(mas);
            //ShowMas(mas);

            Console.WriteLine("Введите a");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите b");
            float b = float.Parse(Console.ReadLine());
            float abs;

            // другой вариант
            for (int i = 0, t = 0; i < n; i++)
            {
                abs = Math.Abs(mas[i]);
                if (!(abs >= a && abs <= b))
                {
                    masTmp[t++] = mas[i];
                }
            }

            ShowMas(masTmp, "Массив после уплотнения:");
        }

        static private void ShowMas(float[] m, string str = "Содержимое массива:")
        {
            Console.WriteLine(str);
            foreach (float i in m)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();
        }

    }
}
