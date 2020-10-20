using System;

/* Лабораторная 4. Простые классы*/
namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Задача 2. Описать  класс,  реализующий  шестнадцатеричный  счетчик,  
             * который  может  увели чивать  или  уменьшать  свое  значение  на  единицу  
             * в  заданном  диапазоне. Предусмотреть инициализацию  счетчика  значениями  
             * по  умолчанию  и  произвольными значениями.  
             * Счетчик  имеет  два  метода:  увеличения  и  уменьшения,  — и  свойство, 
             * позволяющее  получить  его  текущее  состояние.  
             * При  выходе  за  границы  диапазо на  выбрасываются  исключения. 
             * Написать  программу,  демонстрирующую  все  разработанные  элементы  класса.
            */

            // Использование элементов класса Encounter16
            Enconter16 myCount16 = new Enconter16();
            Enconter16 myCount16_2 = new Enconter16(0x4);
            int k;
            try
            {
                for(byte i = 0; i < 10; i++)
                {
                    Console.WriteLine(myCount16.getCounter);
                    myCount16.Decrem();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
            }

            try
            {
                k = myCount16_2.getCounter;
                Console.WriteLine("Значение k = {0}", k);
                myCount16_2.Increm();
                Console.WriteLine(myCount16_2.getCounter);
                myCount16_2.Increm();
                Console.WriteLine(myCount16_2.getCounter);
            }
            catch (Exception e)
            {
                Console.WriteLine("Вышли за границу значений счетчика \n " +
                    "Сообщение {0}, Источник {1}, Стек {2}, Исключение {3}, Данные {4}, Строка {5}", 
                    e.Message, e.Source, e.StackTrace, e.InnerException, e.Data, e.ToString());
            }



            /* Задача 3. Описать  класс,  представляющий  треугольник. 
             * Предусмотреть  методы  для  создания  объектов, перемещения  на  плоскости,  
             * изменения  размеров  и  вращения  на заданный  угол.  
             * Описать  свойства  для  получения  состояния  объекта.  
             * При  невозможности  построения  треугольника  выбрасывается  исключение. 
             * Написать  программу,  демонстрирующую  все  разработанные  элементы  класса.*/
            try
            {
                Triangle myTrian1 = new Triangle();
                Triangle myTrian2 = new Triangle(-2, 1, -3, 3, -1, 3);
                Triangle myTrian3 = new Triangle(3.2, 3.5, 0, 1, 5, 0.1);
                myTrian1.showInfo();
                myTrian2.showInfo();
                myTrian3.showInfo();

                myTrian2.SetTranslate(5,0);
                myTrian2.Name = "Перемещенный треугольник";
                myTrian2.showInfo();

                myTrian3.SetRotate(3, 2, 270);
                myTrian3.Name = "Повернутый треугольник";
                myTrian3.showInfo();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }
    }
}
