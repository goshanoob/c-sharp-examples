using System;
using System.Collections.Generic;
using System.Globalization;

public class Garage
{

    List<Car> queueCar;

    public Garage()
        :this(1)
    {

    }
    public Garage(int n)
    {
        queueCar = new List<Car>(n);
        for(int i = 0; i < n; ++i)
        {
            queueCar = new List<Car>();
        }
    }

    public Garage(Car[] cars)
    {
        queueCar = new List<Car>(cars);
    }

    public class Car
    {
        public string Name { get; } = "Машина";

        
        enum status
        {
            clean, dirty
        }

        status stat;
        public Car() { }

        public Car(string name)
        {
            // авто имеют поле status со значением из перечисления enum clear или dirty
            // или проще: поле типа bool isClean
            Name = name;
            stat = status.dirty;
        }
    }



}


class Washer
{
    // реализовать очередь (параметризованная коллекция) автомобилей
    public static void Wash(Garage.Car car)
    {
        //car.clear;
        Console.WriteLine($"Автомобиль {car.Name} отлично помыт! Приезжайте еще...");
    }
}


class NewWasher
{
    // добавить наблюдателя за действиями экземпляров класса Washer (конкурента)
    public  void Wash(Garage.Car car)
    {
        //car.clear;
        Console.WriteLine($"Только что у нас вы помомыли свой прекрасный {car.Name} " +
            $"всего за 9.99 у.е. на автомойке {this.ToString()}! Вы получаете скидку в 9.99% от следующей мойки! " +
            $"Не упустите воспользоваться купоном до 9.09.99!!!11111адын");
    }


}