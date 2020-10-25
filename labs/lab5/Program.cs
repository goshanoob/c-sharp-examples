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

            /* Задача 18. В одномерном массиве, состоящем из n вещественных элементов, 
             * вычислить: количество элементов массива, меньших С; сумму целых частей 
             * элементов массива, расположенных после последнего отрицательного элемента. 
             * Преобразовать массив таким образом, чтобы сначала располагались все элементы, 
             * отличающиеся от максимального не более чем на 20 %, а потом — все остальные.
            */
            Console.WriteLine("Решаем дальше.. Введите C:");
            float C = Convert.ToInt32(Console.ReadLine());
            ushort count = 0;
            sum = 0;
            for(byte i = 0; i < n; i++)
            {
                if(mas[i] < C)
                {
                    count++;
                }
            }

            // Поиск последнего отрицательного элемента в массиве
            for(int i = n-1; i >= 0; --i)
            {
                if(mas[i] < 0)
                {
                    break;
                }
                sum += (int) Math.Floor(mas[i]);
            }

            Console.WriteLine("Количество элементов массива, меньших {0} равно {1} \n " +
                "Сумма целых частей элементов массива, расположенных после последнего " +
                "отрицательного элемента, равна {2}", C, count, sum);

            float[] masTmp2 = new float[n];
            float elem;
            int start = 0;
            for(int i = 0, p = 0, p1 = 0; i < n; ++i)
            {
                elem = mas[i];
                if ( elem >= max - 0.2*max ){
                    masTmp[p++] = elem;
                    start++;
                } 
                else
                {
                    masTmp2[p1++] = elem;
                }
            }
            Array.Copy(masTmp2, 0, masTmp, start, n-start);
            ShowMas(masTmp, "Массив после перестановок:");
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
