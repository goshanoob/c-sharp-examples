using System;

/* Лабораторная 8. Классы и операции */

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Описать класс для работы с одномерным массивом целых чисел(вектором).
             * Обеспечить следующие возможности: задание произвольных целых границ 
             * индексов при создании объекта; обращение к отдельному элементу массива 
             * с контролем выхода за пределы массива; выполнение операций поэлементного 
             * сложения и вычитания массивов с одинаковыми границами индексов; выполнение 
             * операций умножения и деления всех элементов массива на скаляр; вывод на 
             * экран элемента массива по заданному индексу и всего массива. Написать 
             * программу, демонстрирующую все разработанные элементы класса. 
            */
            try
            {
                Vector v1 = new Vector(10);
                Vector v2 = new Vector(10);
                Console.WriteLine(v1.PrintValue(9));
                // Console.WriteLine(v1.PrintValue(10));
                v1[5] = 332;
                v2[5] = 228;
                Console.WriteLine(v1[5]);
                Console.WriteLine(v1.PrintVector());
                Console.WriteLine(v1.Length);
                Vector v3 = v1 + v2;
                Console.WriteLine(v3.PrintVector());

            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
    }
}
