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
            dx = 1.5f;
            xk = 9;
            x = -15;
            Console.WriteLine("Решаем задачу 4 \n Введите R: ");
            R = float.Parse(Console.ReadLine());
            Console.WriteLine("Значения функции, заданной при помощи ряда тейлора \n" +
                "|   x   |   y   | Кол-во членов ряда | Проверка");

            int maxMember = 1000, membersCount = 1;
            double sum, newMember, oldMember = (2 * 1 - 1) * (2 * 1 + 2) * (2 * 1 + 3) /
                        2 * 1 / Math.Pow(2 * 1 + 1, 2) / -1 / -1;
            // точность
            double e = 0.001;
            for (double i = -0.9; i <= 1; i += 0.1)
            {
                sum = 0;
                membersCount = 0;
                for (int n = 2; n <= maxMember; ++n)
                {
                    membersCount++;
                    newMember = oldMember * (2 * n - 1) * (2 * n + 2) * (2 * n + 3) /
                        2 * n / Math.Pow(2 * n + 1, 2) / i / i;
                    sum += newMember;
                    if (Math.Abs(newMember - e) == 0)
                        break;
                    oldMember = newMember;
                }
                Console.WriteLine("{0,7:F} | {1,7:F3} | {2,10:F} | {3,7:F}\n", i, Math.PI / 2 - sum - i, membersCount, Math.Acos(i));
            }
        }
    }
}
