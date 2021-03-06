﻿using System;

// Лабораторная 9. Наследование

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача 1. В программах требуется описать базовый класс (возможно, абстрактный), в котором с помощью виртуальных или абстрактных методов и свойств 
            // задается интерфейс для производных классов. Целью лабораторной работы является максимальное использование наследования, даже если для конкретной 
            // задачи оно не дает выигрыша в объеме программы. Во всех классах следует переопределить метод Equals, чтобы обеспечить сравнение значений, а не ссылок.
            // Функция Main должна содержать массив из элементов базового класса, заполненный ссылками на производные классы. В этой функции должно демонстрироваться 
            // использование всех разработанных элементов классов.
            // 
            // Создать класс Point (точка). На его основе создать классы ColoredPoint и Line (линия). На основе класса Line создать классы ColoredLine и PolyLine 
            // (многоугольник). В классах описать следующие элементы: конструкторы с параметрами и конструкторы по умолчанию; свойства для установки и получения 
            // значений всех координат, а также для изменения цвета и получения текущего цвета; для линий — методы изменения угла поворота линий относительно первой
            // *точки; для многоугольника — метод масштабирования.

            Point myPoint1 = new Point();
            Console.WriteLine(string.Join(", ", myPoint1.Coord));
            Console.WriteLine("Координаты точки 1: {0}", string.Join(", ", myPoint1.Coord));
            Console.WriteLine($"Координаты точки 1: {myPoint1.X}, {myPoint1.Y}");
            Point myPoint2 = new Point();
            myPoint2.X = 5;
            myPoint2.Y = 6.1f;
            Console.WriteLine("Координаты точки 2: {0}", string.Join(", ", myPoint2.Coord));

            Point myPoint3 = new Point(2.0f, 5.1f);
            Console.WriteLine("Координаты точки 3: {0}", string.Join(", ", myPoint3.Coord));
            myPoint3.Coord = new float[] { 5f, 6.1f };
            Console.WriteLine("Координаты точки 3: {0}, {1}", myPoint3.X, myPoint3.Y);
            Console.WriteLine(myPoint2 == myPoint3);
            Console.WriteLine("Результат сравнения точек 2 с 3 " + myPoint2.Equals(myPoint3));
            Console.WriteLine("Результат сравнения точек 3 с 2 " + myPoint3.Equals(myPoint2));
            Console.WriteLine(myPoint3.Info());

            ColoredPoint myPoint4 = new ColoredPoint();
            myPoint4.Coord = new float[] { 5, 6.1f };
            Console.WriteLine(myPoint4.Info());
            myPoint4.Color = "красный";
            Console.WriteLine("Результат сравнения точек 4 с 3 " + myPoint4.Equals(myPoint3));
            Console.WriteLine("Результат сравнения точек 3 с 4 " + myPoint3.Equals(myPoint4));

            Line myLine1 = new Line();
            Console.WriteLine(myLine1.Info());
            myLine1.Coord = new float[] { 4, -3, 5, -11 };
            Console.WriteLine("Концы отрезка: {0}, {1}, {2}, {3}",
                myLine1.X, myLine1.Y, myLine1.X2, myLine1.Y2);
            myLine1.Rotate(90);
            Console.WriteLine(myLine1.Info());

            ColoredLine myLine2 = new ColoredLine(4, -3, 5, -11, "зеленый");
            Console.WriteLine("Длина отрезка по умолчанию равна " + Math.Sqrt(Math.Pow(myLine2.Y2, 2) + Math.Pow(myLine2.Y2, 2)));
            myLine2.Rotate(-45);
            myLine2.Color = "голубой";
            Console.WriteLine(myLine2.Info());
            Console.WriteLine("Точки: {0}, {1}, {2}, {3}", myLine2.Coord[0], myLine2.Coord[1], myLine2.Coord[2], myLine2.Coord[3]);

            PolyLine myLine3 = new PolyLine { };
            Console.WriteLine(string.Join(", ", myLine3.Coord));
            Console.WriteLine(myLine3.Info());
            myLine3.Coord = new float[] { 4, -3, 5, -11 };
            Console.WriteLine(myLine3.Info());

            PolyLine myLine4 = new PolyLine(1, 1, 6, 6);
            Console.WriteLine(myLine4.Info());
            myLine4.Coord = new float[] { 6, 1, 8, 1 };
            Console.WriteLine(myLine4.Info());
            myLine4.Rotate(-120);
            myLine4.Scale(1, 1.5f);
            Console.WriteLine(myLine4.Info());

            Point[] massiv = new Point[] { myPoint1, myPoint2, myLine1, myLine2, myLine3, myLine4 };
            foreach (Point i in massiv)
            {
                Console.WriteLine(i.Info());
            }


            //  Вариант 3. Описать базовый класс Строка. Обязательные поля класса: поле для 
            // хранения символов строки; значение типа word для хранения длины строки в байтах. 
            // Реализовать обязательные методы следующего назначения: конструктор без 
            // параметров; конструктор, принимающий в качестве параметра строковый литерал; 
            // конструктор, принимающий в качестве параметра символ; метод получения длины 
            // строки; метод очистки строки (сделать строку пустой). Описать производный от 
            // Строка класс Комплексное_число. Строки данного класса состоят из двух полей, 
            // разделенных символом i. Первое поле задает значение действительной части числа, 
            // второе — значение мнимой. Каждое из полей может содержать только символы 
            // десятичных цифр и символы - и +, задающие знак числа. Символы - или + могут 
            // находиться только в первой позиции числа, причем символ + может отсутствовать, 
            // в этом случае число считается положительным. Если в составе инициализирующей 
            // строки будут встречены любые символы, отличные от допустимых, класс 
            // Комплексное_число принимает нулевое значение. Примеры строк: 33i12, -7i100, +5i - 21.
            //  Для класса Комплексное_число определить следующие методы: проверка на равенство; 
            // сложение чисел; умножение чисел.


            // Класс не тестировался.
        }
    }
}
