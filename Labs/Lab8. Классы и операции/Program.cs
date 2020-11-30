using System;

// Лабораторная 8. Классы и операции

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача 1. Описать класс для работы с одномерным массивом целых чисел (вектором).
            // Обеспечить следующие возможности: задание произвольных целых границ 
            // индексов при создании объекта; обращение к отдельному элементу массива 
            // с контролем выхода за пределы массива; выполнение операций поэлементного 
            // сложения и вычитания массивов с одинаковыми границами индексов; выполнение 
            // операций умножения и деления всех элементов массива на скаляр; вывод на 
            // экран элемента массива. Написать 
            // программу, демонстрирующую все разработанные элементы класса. 
            try
            {
                Vector v1 = new Vector(10);
                Vector v2 = new Vector(10);
                Console.WriteLine(v1.PrintValue(9));
                // Console.WriteLine(v1.PrintValue(10));
                for (int i = 0; i < v1.Length; i++)
                {
                    v1[i] = 10 + 4 * i;
                    v2[i] = -48 + 3 * i;
                }
                Console.WriteLine("v1[5] = " + v1[5]);
                Console.WriteLine("v1 = " + v1.PrintVector());
                Console.WriteLine("v2 = " + v2.PrintVector());
                Console.WriteLine("v1.Length = " + v1.Length);
                Vector v3 = v1 + v2;
                Console.WriteLine("v3 = " + v3.PrintVector());
                v3 += 5 * v2 * 2 / 5.7;
                Console.WriteLine("v3 = " + v3.PrintVector());

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //  Задача 12. Описать  класс  «множество»,  позволяющий  выполнять  основные  
            // операции:  добавление  и  удаление  элемента,  пересечение,  объединение 
            // и  разность  множеств. Написать  программу,  демонстрирующую  все  
            // разработанные  элементы  класса.
            try
            {
                Sets animals1 = new Sets();
                Sets animals2 = new Sets("Жираф", "Кенгуру", "Броненосец", "Кенгуру");
                animals1 = animals1.Push("Коала", "Панда", "Бегемот", 5);
                animals1 += animals2;
                animals1 = animals1.Delete(5);
                animals1 -= animals2;
                animals1 = animals1 - "Панда";
                animals1 = animals1 - "Овечка";
                Sets animals3 = animals1.Intersection(animals2);
                animals3 = animals1 + animals2;
                animals3 = animals3.Intersection(animals2);
                animals3 = "Чайка" + animals3 + "Чайка";
                Sets numbers = new Sets(3.1, 4, 6, 2, 3.1, 5, 6, 7, 8, 8, 8, 3.1, 4, 3, 4, 5, 6, 7, 8);
                Sets animals4 = new Sets("Жираф", "Коала", "Жираф", "Коала", "Жираф", "Коала", "Жираф", "Слоник");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
