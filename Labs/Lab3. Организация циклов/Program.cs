using System;

// Лабораторная 3. Организация циклов.

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1.4. Вычислить и вывести на экран в виде таблицы значения 
            // функции, заданной графически, на интервале от хn до хk с шагом dx. 
            // Интервал и шаг задать таким образом, чтобы проверить все ветви 
            // программы. Таблицу снабдить заголовком и шапкой.
            float dx = 1, xk = 10, x = -15, y, R;
            Console.WriteLine("Решаем задачу 4 \n Введите R: ");
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
                Console.WriteLine("{0,7:#0.##} | {1,6:#0.000}", x, y);
                x += dx;
            }

            // Задание 1.8
            Console.WriteLine("------------------");
            dx = 1;
            xk = 10;
            x = -11;
            Console.WriteLine("Решаем задачу 8 \n Введите R: ");
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
                    result = (Math.Sqrt(R * R - Math.Pow(x + 6 + R, 2)) - 2).ToString("F3");
                }
                else if (x < 2)
                {
                    result = (0.5 * x + 1).ToString("F3");
                }
                else if (x < 6)
                {
                    result = "0.000";
                }
                else if (x <= 8)
                {
                    result = Math.Pow(x - 6, 2).ToString("F3");
                }
                else
                {
                    result = "Функция не определена";
                }
                Console.WriteLine("{0,7:#0.##} | {1,6}", x, result);
                x += dx;
            }

            // Задание 2.10. Для десяти выстрелов, координаты которых задаются с клавиатуры, 
            // вывести текстовые сообщения о попадании в мишень из задания 2 лабораторной работы 2.
            Console.WriteLine("------------------");
            int shotCount = 0, hitCount = 0;
            float a, b, squareSum, squareR;
            Console.WriteLine("Решаем задачу 10. Введите R");
            R = Single.Parse(Console.ReadLine());
            Console.WriteLine("Введите a (половина ширины прямоугольника)");
            a = Single.Parse(Console.ReadLine());
            Console.WriteLine("Введите b (половина высоты прямоугольника)");
            b = Single.Parse(Console.ReadLine());
            for (int i = 0; i < shotCount; ++i)
            {
                Console.WriteLine("Введите координату x выстрела:");
                x = Single.Parse(Console.ReadLine());
                Console.WriteLine("Введите координату y выстрела:");
                y = Single.Parse(Console.ReadLine());
                squareSum = x * x + y * y;
                squareR = R * R;
                if (squareSum <= squareR && y >= -b && y <= 0 && x >= -a && x <= 0 ||
                   squareSum >= squareR && y >= 0 && y <= b && x >= 0 && x <= a)
                {
                    Console.WriteLine("Попали!");
                    hitCount++;
                }
                else
                {
                    Console.WriteLine("На этот раз мимо.");
                }
            }
            Console.WriteLine($"В результате {hitCount} попаданий(-е, -я) и {shotCount - hitCount} промах(-ов, -а).");

            // Задача 3.20. Вычислить и вывести на экран в виде таблицы значения функции, заданной с помощью ряда 
            // Тейлора, на интервале от хn до хk с шагом dx с точностью e. Таблицу снабдить заголовком 
            // и шапкой. Каждая строка таблицы должна содержать значение аргумента, значение функции и 
            // количество просуммированных членов ряда.
            Console.WriteLine("Решаем задачу 3.20");
            Console.WriteLine("Значения функции, заданной при помощи ряда тейлора \n" +
                "|   x   |   y   | Кол-во членов ряда | Проверка");
            // Ограничение по количеству членов ряда, счетчик их количества.
            const int maxMembersCount = 10000;
            int membersCount = 1;
            double getMember(double x)
            {
                // Сумма членов ряда, n-й член ряда, точность.
                double sum = x, yn = x, e = 1e-6, n = 0;

                while (e < Math.Abs(yn))
                {
                    if (n == maxMembersCount)
                        break;
                    yn *= x * x * (2 * n + 1) * (2 * n + 1);
                    yn /= 2 * (n + 1) * (2 * n + 3);
                    //yn *= n * x * x * Math.Pow(2 * n + 1, 2) / ((2 * n - 1) * (n + 1) * (2 * n + 3));
                    //yn *= x * x / (16 * Math.Pow(n, 4) + 32 * Math.Pow(n, 3) + 4 * n * n - 12 * n);
                    sum += yn;
                    ++n;
                    ++membersCount;
                }
                return Math.PI / 2 - sum;
            }
            dx = 0.1f;
            xk = 1;
            x = -1;
            while (x <= xk)
            {
                membersCount = 1;
                Console.WriteLine("{0,7:F} | {1,7:F5} | {2,9:F}| {3,7:F5}\n",
                    x, getMember(x), membersCount, Math.Acos(x));
                x += dx;
            }
        }
    }
}
