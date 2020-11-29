using System;

// Лабораторная 1. Линейные программы. Напишите программу для расчета по двум формулам.

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача 13.
            Console.WriteLine("Введите альфу, плз: ");
            double alpha = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите бетту, плз: ");
            double betta = double.Parse(Console.ReadLine());
            double q = 2 * betta - alpha;
            double z1 = (Math.Sin(alpha) + Math.Cos(q)) / (Math.Cos(alpha) - Math.Sin(q));
            Console.WriteLine("Результат z1 = {0}", z1);

            // Задача 15.
            double b, b1;
            do
            {
                Console.WriteLine("Введите b, плз: ");
                b = Double.Parse(Console.ReadLine());
                if (b > -2 && b < 2)
                {
                    Console.WriteLine("Вы ввели недопустимое значение");
                    continue;
                }
                else
                {
                    break;
                }
            } while (true);
            b1 = Math.Sqrt(Math.Pow(b, 2) - 4);
            z1 = Math.Sqrt(2 * b + 2 * b1) / (b1 + b + 2);
            Console.WriteLine("Новый результат z1 = {0}", z1);
        }
    }
}
