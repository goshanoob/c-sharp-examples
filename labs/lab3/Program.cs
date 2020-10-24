using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Лабораторная 3*/

            // Задание 1. Таблица значений функции
            // Вариант 4
            sbyte dx = 1, xk = 10;
            float x = -15, y, R;
            Console.WriteLine("Решаем вариант 4 \n Введите R: ");
            R = float.Parse(Console.ReadLine());
            Console.WriteLine("|   x   |   y   |");
            while (x <= xk)
            {
                if (x <= 0)
                {
                    y = -R / 6 * x - R;
                }
                else if (x <= R)
                {
                    y = (float)-Math.Sqrt(R * R - x * x);
                }
                else if (x < 2 * R)
                {
                    y = (float)Math.Sqrt(R * R - Math.Pow(x - 2 * R, 2));
                }
                else
                {
                    y = 0;
                }
                Console.WriteLine("{0,7} | {1,7}", x, y);
                x += dx;
            }

            // Вариант 8
            Console.WriteLine("------------------");
            dx = 1;
            xk = 10;
            x = -11;
            Console.WriteLine("Решаем вариант 8 \n Введите R: ");
            R = float.Parse(Console.ReadLine());
            string result;
            Console.WriteLine("|   x   |   y   |");
            while (x <= xk)
            {
                if (x < -6 - 2 * R)
                {
                    result = "Функция не определена";
                }
                else if (x < -6)
                {
                    result = ((float)Math.Sqrt(R * R - Math.Pow(x + 6 + R, 2)) - 2).ToString();
                }
                else if (x < 2)
                {
                    result = ((float)0.5 * x + 1).ToString();
                }
                else if (x < 6)
                {
                    result = "0";
                }
                else if (x <= 8)
                {
                    result = ((float)Math.Pow(x - 6, 2)).ToString();
                }
                else
                {
                    result = "Функция не определена";
                }

                Console.WriteLine("{0,7} | {1,7}", x, result);
                x += dx;
            }
        }
    }
}
