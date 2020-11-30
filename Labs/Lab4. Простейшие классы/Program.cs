using System;

// Лабораторная 4. Простейшие классы. 

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача 2. Описать класс, реализующий шестнадцатеричный счетчик, 
            // который может увеличивать или уменьшать свое значение на единицу 
            // в заданном диапазоне. Предусмотреть инициализацию счетчика значениями 
            // по умолчанию и произвольными значениями. 
            // Счетчик имеет два метода: увеличения и уменьшения, — и свойство, 
            // позволяющее получить его текущее состояние. 
            // При выходе за границы диапазо на выбрасываются исключения. 
            // Написать программу, демонстрирующую все разработанные элементы класса.

            // Использование элементов класса Encounter16
            Enconter16 myCount16 = new Enconter16(0x4);
            Enconter16 myCountNext = new Enconter16();
            try
            {
                for (byte i = 0; i < 20; i++)
                {
                    int hexValue = myCount16.GetCounter;
                    Console.Write(myCount16.GetCounter);
                    Console.WriteLine($", в шестнадцатеричном виде: {myCount16.GetCounter:X}");
                    myCount16.Increm();
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Исключение выхода за границу диапазона! {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Значение счетчика до инкремента: {0}", myCountNext.GetCounter);
                myCountNext.Increm();
                Console.WriteLine(myCountNext.GetCounter);
                myCountNext.Increm();
                Console.WriteLine(myCountNext.GetCounter);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Выход за границу допустимого диапазона");
            }
            catch (Exception e)
            {
                Console.WriteLine("Вышли за границу значений счетчика \n " +
                    "Сообщение: {0},\n Источник {1},\n Стек {2},\n Исключение {3},\n Данные {4},\n Строка {5}",
                    e.Message, e.Source, e.StackTrace, e.InnerException, e.Data, e.ToString());
            }

            // Задача 3. Описать класс, представляющий треугольник. 
            // Предусмотреть методы для создания объектов, перемещения на плоскости, 
            // изменения размеров и вращения на заданный угол. 
            // Описать свойства для получения состояния объекта. 
            // При невозможности построения треугольника выбрасывается исключение. 
            // Написать программу, демонстрирующую все разработанные элементы класса.
            try
            {
                Triangle myTriangle1 = new Triangle();
                Triangle myTriangle2 = new Triangle(-2, 1, -3, 3, -1, 3);
                Triangle myTriangle3 = new Triangle(3.2, 3.5, 0, 1, 5, 0.1);
                myTriangle1.showInfo();
                myTriangle2.showInfo();
                myTriangle3.showInfo();

                myTriangle2.SetTranslate(5, 0);
                myTriangle2.Name = "Перемещенный треугольник";
                myTriangle2.showInfo();

                myTriangle3.SetRotate(3, 2, 270);
                myTriangle3.Name = "Повернутый треугольник";
                myTriangle3.showInfo();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Задача 4. Построить описание класса, содержащего информацию о почтовом адресе организации. 
            // Предусмотреть возможность раздельного изменения составных частей адреса и 
            // проверки допустимости вводимых значений. В случае недопустимых значений полей 
            // выбрасываются исключения. Написать программу, демонстрирующую все разработанные 
            // элементы класса.
            try
            {
                Mailer myPost = new Mailer("228228", "Miass", "lenina", "17");
                Mailer myPostAddress = new Mailer();
                while (true)
                {
                    Console.WriteLine("Добрый день! Это программа для ввода почтового адреса организации!\n" +
                        "Текущий адрес: {0}.\n Нажмите 1, если хотите поменять индекс, \n 2 - город \n" +
                        "3 - улицу \n 4 - здание, q - выйти.", myPostAddress.ShowAddres());
                    string buf1 = Console.ReadLine(), buf2, info;
                    switch (buf1)
                    {
                        case "1": info = string.Format("Текущий почтовый индекс {0}", myPostAddress.Post); break;
                        case "2": info = string.Format("Текущий город {0}", myPostAddress.Сity); break;
                        case "3": info = string.Format("Текущая улица {0}", myPostAddress.Street); break;
                        case "4": info = string.Format("Текущее здание {0}", myPostAddress.Estate); break;
                        case "q": return;
                        default: info = "Вы нажали другую клавишу"; break;
                    }
                    Console.WriteLine(info + ". Введите новое значение или отмените ввод (Enter).");
                    buf2 = Console.ReadLine();
                    if (buf2 == "")
                    {
                        continue;
                    }
                    switch (buf1)
                    {
                        case "1": myPostAddress.Post = buf2; break;
                        case "2": myPostAddress.Сity = buf2; break;
                        case "3": myPostAddress.Street = buf2; break;
                        case "4": myPostAddress.Estate = buf2; break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Задача 7. Составить описание класса прямоугольников со сторонами, параллельными осям 
            // координат. Предусмотреть возможность перемещения прямоугольников на плоскости, 
            // изменение размеров, построение наименьшего прямоугольника, содержащего два заданных 
            // прямоугольника и прямоугольника, являющегося общей частью (пересечением) двух 
            // прямоугольников. Написать программу, демонстрирующую все разработанные элементы класса.*/

            Rect a = new Rect(new double[8] { 1, 2, 3, 4, 5, 6, 7, 8 });

        }
    }
}
