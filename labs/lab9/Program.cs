using System;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
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



        }
    }
}
