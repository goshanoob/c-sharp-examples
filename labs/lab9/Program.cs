using System;

/* Лабораторная 9. Наследование */

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Задача 9. В программах требуется описать базовый класс (возможно, абстрактный), в котором с помощью виртуальных или абстрактных методов и свойств 
             * задается интерфейс для производных классов. Целью лабораторной работы является максимальное использование наследования, даже если для конкретной 
             * задачи оно не дает выигрыша в объеме программы. Во всех классах следует переопределить метод Equals, чтобы обеспечить сравнение значений, а не ссылок.
             * Функция Main должна содержать массив из элементов базового класса, заполненный ссылками на производные классы. В этой функции должно демонстрироваться 
             * использование всех разработанных элементов классов.
             * 
             * Создать класс Point (точка). На его основе создать классы ColoredPoint и Line (линия). На основе класса Line создать классы ColoredLine и PolyLine 
             * (многоугольник). В классах описать следующие элементы: конструкторы с параметрами и конструкторы по умолчанию; свойства для установки и получения 
             * значений всех координат, а также для изменения цвета и получения текущего цвета; для линий — методы изменения угла поворота линий относительно первой
             * точки; для многоугольника — метод масштабирования.
             */

            Point myPoint1 = new Point();
            Console.WriteLine("Координаты точки 1: {0}, {1}", myPoint1.Coord[0], myPoint1.Coord[1]);
            Console.WriteLine("Координаты точки 1: {0}, {1}", myPoint1.X, myPoint1.Y);
            Point myPoint2 = new Point();
            myPoint2.X = 5;
            myPoint2.Y = 6.1f;
            Console.WriteLine("Координаты точки 2: {0}, {1}", myPoint2.Coord[0], myPoint2.Coord[1]);
            Point myPoint3 = new Point(2.0f, 5.1f);
            Console.WriteLine("Координаты точки 3: {0}, {1}", myPoint3.Coord[0], myPoint3.Coord[1]);
            myPoint3.Coord = new float[] { 5f, 6.1f };
            Console.WriteLine("Координаты точки 3: {0}, {1}", myPoint3.X, myPoint3.Y);
            Console.WriteLine(myPoint2 == myPoint3);
            Console.WriteLine(myPoint2.Equals(myPoint3));
            Console.WriteLine(myPoint3.Info());

            ColoredPoint myPoint4 = new ColoredPoint();
            myPoint4.Coord = new float[] { 5, 6.1f };
            Console.WriteLine(myPoint4.Info());
            myPoint4.Color = "красный";
            Console.WriteLine(myPoint4.Equals(myPoint3));

            Line myLine1 = new Line();
            Console.WriteLine(myLine1.Info());
            myLine1.Coord = new float[] { 4, -3, 5, -11 };
            Console.WriteLine("Концы отрезка: {0}, {1}, {2}, {3}",
                myLine1.X, myLine1.Y, myLine1.X2, myLine1.Y2);
            myLine1.Rotate(90);
            Console.WriteLine(myLine1.Info());

            ColoredLine myLine2 = new ColoredLine(4, -3, 5, -11, "зеленый");
            Console.WriteLine("Длина отрезка по умолчанию равна " + Math.Sqrt(Math.Pow(myLine2.Y2, 2) + Math.Pow(myLine2.Y2, 2)));
            float[] co = myLine2.Rotate(-45);
            myLine2.Color = "голубой";
            Console.WriteLine(myLine2.Info());
            Console.WriteLine("Точки: {0}, {1}, {2}, {3}", myLine2.Coord[0], myLine2.Coord[1], myLine2.Coord[2], myLine2.Coord[3]);

            PolyLine myLine3 = new PolyLine(1, 1, 6, 1, 8, 4, 3.5f, 7, -1, 4);
            Console.WriteLine(myLine3.Info());

            int a = 5;
        
        }
    }
}
