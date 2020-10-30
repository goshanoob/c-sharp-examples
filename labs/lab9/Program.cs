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
            Console.WriteLine(myLine3.Info());
            myLine3.Coord = new float[] { 4, -3, 5, -11 };

            PolyLine myLine4 = new PolyLine( 1, 1, 6, 6 );
            Console.WriteLine(myLine4.Info());
            myLine4.Coord = new float[] { 6, 1 };
            Console.WriteLine(myLine4.Info());


            int[] a = new int[] { 1, 2, 4, 56 };

            Console.WriteLine(string.Join(" ", a));
        
        }
    }
}
