using System;

namespace lab9
{
    class Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        virtual public float[] Coord
        {
            get
            {
                return new float[2] { X, Y };
            }
            set
            {
                X = value[0];
                Y = value[1];
            }
        }

        virtual public string Info()
        {
            return string.Format("Точка с координатами x = {0}, y = {1}", X, Y);
        }


        public Point() { }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Point tmpObj = (Point)obj;
            return tmpObj.X == this.X && tmpObj.Y == this.Y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    class ColoredPoint : Point
    {
        public string Color { get; set; } = "черный";
        public ColoredPoint() { }
        public ColoredPoint(string color)
        {
            Color = color;
        }
        public ColoredPoint(float x, float y, string color) : base(x, y)
        {
            Color = color;
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;
            ColoredPoint tmpObj = (ColoredPoint)obj;
            return X == tmpObj.X && Y == tmpObj.Y && Color == tmpObj.Color;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string Info()
        {
            return base.Info() + string.Format(". Цвет {0}", Color);
        }
    }

    class Line : Point
    {
        // константы для перевода градусов в радианы и обратно
        const float gR = (float)(Math.PI / 180), rG = (float)(180 / Math.PI);
        public float X2 { get; set; } = 1;
        public float Y2 { get; set; } = 1;
        public Line() { }
        public Line(float x1, float y1, float x2, float y2) : base(x1, y1)
        {
            X2 = x2;
            Y2 = y2;
        }

        public override float[] Coord
        {
            get
            {
                return new float[] { X, Y, X2, Y2 };
            }

            set
            {
                X = value[0];
                Y = value[1];
                X2 = value[2];
                Y2 = value[3];
            }
        }

        virtual public void Rotate(float alpha)
        {
            float sa = (float)Math.Sin(gR * alpha), ca = (float)Math.Cos(gR * alpha),
            x2 = X2 - X, y2 = Y2 - Y;
            X2 = x2 * ca - y2 * sa + X;
            Y2 = x2 * sa + y2 * ca + Y;
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;
            Line tmpObj = (Line)obj;
            return X == tmpObj.X && Y == tmpObj.Y && X2 == tmpObj.X2 && Y2 == tmpObj.Y2;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string Info()
        {
            return string.Format("Линия с координатами начала x1 = {0}, y1 = {1} и" +
                "\nконца x2 = {2}, y2 = {3}", X, Y, X2, Y2);
        }
    }

    class ColoredLine : Line
    {
        public string Color { get; set; } = "черный";
        public ColoredLine()
        {

        }
    }

    class PolyLine : Line
    {
        public PolyLine()
        {

        }
    }
}
