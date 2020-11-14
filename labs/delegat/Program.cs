using System;

namespace delegat
{
    public delegate void IntSet(int x, int y);
    internal delegate void CalcPoints(Point a, Point b);
    delegate void VectorDelegate(Point a, Point b);

    delegate void WashDelegate(Garage.Car car);

    delegate void DelAttantion(Garage.Car car);

    delegate void EventTest(object point);
    
    class Program
    {
        
        static void Main(string[] args)
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);
            Fraction frac1 = new Fraction(1, 1);

            //IntSet del1 = new IntSet(point1.SetValues);
            // короче так:
            IntSet  del1 = point1.SetValues;
            del1(3,3);
            Console.WriteLine(point1.ToString());

            del1 += point2.SetValues;
            del1 += frac1.SetValues;
            del1(10, 10);
            ShowValues();

            del1 -= point2.SetValues;
            del1(21, 21);
            ShowValues();

            del1 -= frac1.SetValues;

            IntSet del2 = del1;
            del2(99,99);
            ShowValues();

            // сложение и вычитание точек
            
            CalcPoints calc = Point.AddPoint;
            calc(point1, point2); // сумма точек 1 и 2
            ShowValues();

            point2.Calculate(point1, calc); // сумма точек 1 и 2
            ShowValues();

            calc = Point.SubPoint;
            point2.Calculate(point1, calc); // разность точек 2 и 1
            ShowValues();

            void ShowValues()
            {
                Console.WriteLine("point1: " + point1.ToString());
                Console.WriteLine("point2: " + point2.ToString());
                Console.WriteLine("frac1: " + frac1.ToString());
                Console.WriteLine("-----");
            }

            // Тестирование класса Vector
            Vector myVec = new Vector(new Point[] { new Point(1,1), 
                                                    new Point (2,2), 
                                                    new Point(3,3)});
            VectorDelegate vecDel = Point.AddPoint;
            myVec.Calculate(new Point(10,10), vecDel);
            
            foreach(Point p in myVec)
            {
                Console.WriteLine(p.ToString());
            }


            /* Задача. Разработайте классы автомобиль Car, гараж Garage, мойка Washer. 
             * Гараж - коллекция автомобилей. Мойка - независимое предприятие, которое может 
             * только мыть автомобиль методом Wash. Делегируйте помывку всех автомобоилей 
             * предприятию. 
             */
            // тестрование класса помывка машин
            Garage.Car car1 = new Garage.Car("audi x7");
            Washer wash1 = new Washer();
            WashDelegate del = wash1.Wash;
            del(car1);
            Garage.Car car = new Garage.Car();

            Garage.Car[] cars = new Garage.Car[10];
            for(int i = 0; i < 10; ++i)
            {
                cars[i] = new Garage.Car();
            }

            Garage gar1 = new Garage(cars);
            Garage gar2 = new Garage();
            int a = 5;

            
            NewWasher wash2 = new NewWasher();
            wash1.DelRegister(wash2.Attantion); // подписались на события
            wash1.Wash(car);


            // терстирование событий
            point1.SetEvent += TestEvent;
            point1.SetValues(100, 100);
            point1.SetEvent -= TestEvent;
            point1.SetValues(0, 0);
            void TestEvent(object p){
                Console.WriteLine("Произошла установка свойств объекта Point!");
                Console.WriteLine($"Получили объект! {p.ToString()}");
            }


        }


    }
}
