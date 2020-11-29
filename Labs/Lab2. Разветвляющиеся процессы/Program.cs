using System;

// Лабораторная 2. Разветвляющиеся вычислительные процессы.

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача 1.4. Написать программу, которая по введенному значению аргумента вычисляет значение
            // функции, заданной в виде графика. Параметр R вводится с клавиатуры.
            while (true)
            {
                Console.WriteLine("Решаем задачу 4 \n Введите R (q - выход): ");
                string buf = Console.ReadLine();
                if (buf == "q")
                    break;
                double y, R = double.Parse(buf);
                Console.WriteLine("Введите аргумент x: ");
                double x = double.Parse(Console.ReadLine());
                if (x <= 0)
                {
                    y = -R / 6 * x - R;
                }
                else if (x <= R)
                {
                    y = -Math.Sqrt(R * R - x * x);
                }
                else if (x < 2 * R)
                {
                    y = Math.Sqrt(R * R - Math.Pow(x - 2 * R, 2));
                }
                else
                {
                    y = 0;
                }
                Console.WriteLine("Получили y = " + y);
            }

            // Задача 1.8. 
            while (true)
            {
                Console.WriteLine("Решаем задачу 8 \n Введите R (q - выход): ");
                string buf = Console.ReadLine();
                if (buf == "q")
                    break;
                double y, R = double.Parse(buf);
                Console.WriteLine("Введите аргумент x: ");
                double x = double.Parse(Console.ReadLine());
                if (x < -6 - 2 * R)
                {
                    Console.WriteLine("Функция не определена");
                }
                else if (x < -6)
                {
                    y = Math.Sqrt(R * R - Math.Pow(x + 6 + R, 2)) - 2;
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
                }
                else
                {
                    Console.WriteLine("Функция не определена");
                }
            }

            // Задача 2.10. Написать программу, которая определяет, попадает ли точка с заданными
            // координатами в область, закрашенную на рисунке серым цветом.
            // Результат работы программы вывести в виде текстового сообщения.
            while (true)
            {
                Console.WriteLine("Решаем задачу 10 \n Введите R (q - выход): ");
                string buf = Console.ReadLine();
                if (buf == "q")
                    break;
                double R = Convert.ToDouble(buf), a, b, x, y;
                Console.WriteLine("Решаем задачу 10 \n Введите a (половина ширины прямоугольника): ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Решаем задачу 10 \n Введите b (половина высоты прямоугольника): ");
                b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите координату x: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите координату y: ");
                y = Convert.ToDouble(Console.ReadLine());
                double squareSum = x * x + y * y, squareR = R * R;
                // В отрицательной полуоси X находим объединение окружности и прямоугольника,
                // а в положительной - разность пространства прямоугольника и окружности.
                if (squareSum <= squareR && y >= -b && y <= 0 && x >= -a && x <= 0 ||
                    squareSum >= squareR && y >= 0 && y <= b && x >= 0 && x <= a)
                {
                    Console.WriteLine("Точка внутри закрашенной области. Ура!");
                }
                else
                {
                    Console.WriteLine("Точка вне закрашенной области.");
                }
            }
        }
    }
}