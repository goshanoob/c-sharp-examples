using System;

/* Лабораторная 4. Простые классы */

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
             * Написать  программу,  демонстрирующую  все  разработанные  элементы  класса.
             */
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


            /* Задача 4. Построить  описание  класса,  содержащего  информацию  о  почтовом  адресе  организации.  
             * Предусмотреть  возможность  раздельного  изменения  составных  частей адреса  и  
             * проверки  допустимости  вводимых  значений.  В  случае  недопустимых значений  полей  
             * выбрасываются  исключения. Написать  программу,  демонстрирующую  все  разработанные  
             * элементы  класса. */
           /* try
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

            */
            /* Задача 6. Составить описание класса для вектора, заданного координатами его концов в 
             * трехмерном пространстве. Обеспечить операции сложения и вычитания векторов с получением 
             * нового вектора (суммы или разности), вычисления скалярного произведения двух векторов, 
             * длины вектора, косинуса угла между векторами. Написать программу, демонстрирующую все 
             * разработанные элементы класса.
             */



            /* Задача 7. Составить описание класса прямоугольников со сторонами, параллельными осям 
             * координат. Предусмотреть возможность перемещения прямоугольников на плоскости, 
             * изменение размеров, построение наименьшего прямоугольника, содержащего два заданных 
             * прямоугольника и прямоугольника, являющегося общей частью (пересечением) двух 
             * прямоугольников. Написать программу, демонстрирующую все разработанные элементы класса.*/

            Rect a = new Rect(new double[8]{1,2,3,4,5,6,7,8});

        }
    }
}
