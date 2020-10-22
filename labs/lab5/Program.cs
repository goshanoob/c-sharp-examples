using System;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите n");
            int n = Int32.Parse(Console.ReadLine());
            float[] mas = new float[n], mas1 = new float[n];
            int k = -1;
            double sum = 0;
            float max;
            Random rnd = new Random();

            for (int i = 0; i < n; ++i)
            {
                mas[i] = (float)rnd.NextDouble() * 200 - 100; // все четные??
            }

            ShowMas(mas);

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
                Console.WriteLine("В массиве последний положительный элемент равен {0}, его индекс {1}", mas[k], k);
            }

            for (int i = 0; i < k; i++)
            {
                sum += mas[i];
            }

            Console.WriteLine("Сумма элементов массива, расположенных до последнего положительного элемента равна " + sum);
            Array.Sort(mas);
            ShowMas(mas);


            Console.WriteLine("Введите a");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите b");
            float b = float.Parse(Console.ReadLine());
            float abs;
            int f = 1;
            for (int i = 0; i < n; i++)
            {
                abs = Math.Abs(mas[i]);
                if (abs >= a && abs <= b)
                {
                    for (int j = i; j < n - 1; ++j)
                    {
                        mas[j] = mas[j + 1];
                    }
                    mas[n - f++] = 0;
                    --i;
                }
            }

            // другой вариант
            for (int i = 0, t = 0; i < n; i++)
            {
                abs = Math.Abs(mas[i]);
                if (!(abs >= a && abs <= b))
                {
                    mas1[t++] = mas[i];
                }
            }

            ShowMas(mas);
            ShowMas(mas1);
            

            void ShowMas(float[] m)
            {
                foreach (float i in m)
                {
                    Console.Write(i + "\t");
                }
            }
        }
    }
}
