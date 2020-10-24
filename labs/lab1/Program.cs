using System;

/* Лабораторная 1. Линейные программы */

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Задача 13
            Console.WriteLine("Введите альфу, плз: ");
            double altha = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите бетту, плз: ");
            double betta = double.Parse(Console.ReadLine());
            double z1 = (Math.Sin(altha) + Math.Cos(2 * betta - altha)) / (Math.Cos(altha) - Math.Sin(2 * betta - altha));
            Console.WriteLine("Результат z1 = {0}", z1);

            // Задача 15
            bool flag = true;
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
                flag = !flag;
            } while (flag);
            b1 = Math.Sqrt(Math.Pow(b, 2) - 4);
            z1 = Math.Sqrt(2 * b + 2 * b1) / (b1 + b + 2);
            Console.WriteLine("Новый результат z1 = {0}", z1);


        }
    }
}
