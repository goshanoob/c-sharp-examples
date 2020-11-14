using System;
using System.Collections.Generic;

namespace delegat
{
    public class Garage
    {
        List<Car> listCar; // список автомобилей в гараже
        public Garage()
            : this(1)
        { }
        public Garage(int n)
        {
            listCar = new List<Car>(n);
            foreach (Car i in listCar)
            {
                listCar.Add(new Car());
            }
        }
        public Garage(Car[] cars)
        {
            listCar = new List<Car>(cars);
        }
        public class Car
        {
            public string Name { get; }
            public status stat;
            public enum status
            {
                // авто имеют статус из перечисления: чистый либо грязный
                clean, dirty
            }
            public Car() {
                Name = "Машина"; // имя по умолчанию
                stat = status.dirty; // статус по умолчанию
            }
            public Car(string name)
            {
                Name = name;
                stat = status.dirty;
            }
        }
    }


    class Washer
    {
        DelAttantion delAttant;
        // реализовать очередь (параметризованная коллекция) автомобилей
        public void Wash(Garage.Car car)
        {
            Console.WriteLine($"Автомобиль {car.Name} отлично помыт! Приезжайте еще...");
            if (delAttant != null) delAttant(car);
        }
        public void DelRegister(DelAttantion del)
        {
            delAttant += del;
        }
    }
    class NewWasher
    {
        // добавить наблюдателя за действиями экземпляров класса Washer (конкурента)
        public void Wash(Garage.Car car)
        {
            Console.WriteLine($"Только что у нас вы помомыли свой прекрасный {car.Name} " +
                $"всего за 9.99 у.е. на автомойке {this.ToString()}! Вы получаете скидку в 9.99% от следующей мойки! " +
                $"Не упустите воспользоваться купоном до 9.09.99!!!11111адын");
        }
        public void Wash(Queue<Garage.Car> cars)
        {
            Garage.Car car;
            while (cars.Count != 0)
            {
                car = cars.Dequeue();
                car.stat = Garage.Car.status.clean;
                Console.WriteLine($"Ваш мегаавтомобоиль {car.Name} сияет чистотой! И всего за 9.99! В честь чистоты" +
                    $"мы дарим вам бесплатную помышву для каждой новой мышины, приобретенной в период до рождества христова" +
                    $"Только в NewWasher и только в термидоре!");
            }
        }
        public void Attantion(object company)
        {
            Console.WriteLine($"Мы обнаружили, что вы только что помыли свой авто в компании {company.ToString()} - " +
                $"самом ужастном места на земле! К счастью, мы предоставляем вас 99.999%* скидку на услуги в нашей" +
                $"автомойке {this.ToString()}! Мойте свой автопарк только у нас! Мы моем машины, а не деньги.");
        }
    }
}