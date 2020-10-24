using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Лабораторная 2 */

            // Вариант 4
            while (true)
            {
                Console.WriteLine("Решаем вариант 4 \n Введите R (q - выход): ");
                string buf = Console.ReadLine();
                if(buf == "q") break;
                double y, R = double.Parse(buf);
                Console.WriteLine("Введите аргумент x: ");
                double x = double.Parse(Console.ReadLine());
                if (x <= 0)
                {
                    y = -R / 6 * x - R;
                } else if (x <= R)
                {
                    y = - Math.Sqrt(R * R - x * x);
                }
                else if (x < 2*R) 
                {
                    y = Math.Sqrt(R * R - Math.Pow(x-2*R, 2));
                } else
                {
                    y = 0;
                }
                Console.WriteLine("Получили y = " + y);
            }

            // Вариант 8
            while (true)
            {
                Console.WriteLine("Решаем вариант 8 \n Введите R (q - выход): ");
                string buf = Console.ReadLine();
                if (buf == "q") break;
                double y, R = double.Parse(buf);
                Console.WriteLine("Введите аргумент x: ");
                double x = double.Parse(Console.ReadLine());
                if (x < -6 - 2*R)
                {
                    Console.WriteLine("Функция не определена");
                }
                else if (x < -6)
                {
                    y = Math.Sqrt(R * R - Math.Pow(x+6+R,2)) - 2;
                    Console.WriteLine("y = " + y);
                }
                else if (x < 2)
                {
                    y = 1.0 / 2.0 * x + 1;
                    Console.WriteLine("y = " + y);
                }
                else if (x < 6)
                {
                    y = 0;
                    Console.WriteLine("y = " + y);
                }
                else if (x <= 8)
                {
                    y = Math.Pow(x - 6, 2);
                    Console.WriteLine("y = " + y);
                } else
                {
                    Console.WriteLine("Функция не определена");
                }
            }

        }
    }
}
