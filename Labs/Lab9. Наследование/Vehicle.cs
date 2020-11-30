namespace lab9
{
    abstract class Vehicle
    {
        public float Cost { get; set; } = 1000;
        public float Speed { get; set; } = 0;
        public short ReliseYear { get; set; } = 2000;
        public double Coordinates { get; set; } = 0.0;
        protected int Power { get; set; } = 1;

        public string Move()
        {
            Coordinates += Power * Speed;
            return $"Средство переместилось в точку {Coordinates}";
        }

        // abstract public string Info();
    }

    class Plane : Vehicle
    {
        public short Height { get; set; } = 3000;
        public short Passengers { get; set; } = 80;
    }

    class Car : Vehicle
    {
        public string Mark { get; set; } = "Audi";
        public float Engine { get; set; } = 2.0f;
        
    }

    class Ship : Vehicle
    {
        public short Passengers { get; set; } = 80;
        public string Port { get; set; } = "Мурманск";
    }
}
