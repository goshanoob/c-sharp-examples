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
            if ((object)this == obj) return true;

            if (obj == null || obj.GetType() != this.GetType()) return false;

            Point tmpObj = (Point)obj;
            return tmpObj.X == this.X && tmpObj.Y == this.Y;
        }

        public override int GetHashCode()
        {
            return (X, Y, Coord).GetHashCode();
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
            if ((object)this == obj) return true;

            if (obj == null || this.GetType() != obj.GetType()) return false;

            ColoredPoint tmpObj = (ColoredPoint)obj;
            return X == tmpObj.X && Y == tmpObj.Y && Color == tmpObj.Color;
        }

        public override int GetHashCode()
        {
            return (X, Y, Coord, Color).GetHashCode();
        }

        public override string Info()
        {
            return base.Info() + string.Format(". Цвет {0}", Color);
        }
    }

    class Line : Point
    {
        // константы для перевода градусов в радианы и обратно
        protected const float gR = (float)(Math.PI / 180), rG = (float)(180 / Math.PI);
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

        public void Rotate(float alpha)
        {
            float sa = (float)Math.Sin(gR * alpha), ca = (float)Math.Cos(gR * alpha);
            /*
            x2 = X2 - X, y2 = Y2 - Y;
            X2 = x2 * ca - y2 * sa + X;
            Y2 = x2 * sa + y2 * ca + Y;
            */

            // универсальный метод для произвольного количества вершин
            float[] tmpCoord = new float[Coord.Length];
            float x0 = Coord[0], y0 = Coord[1];
            tmpCoord[0] = x0;
            tmpCoord[1] = y0;
            for (int i = 2; i < Coord.Length; i += 2)
            {
                tmpCoord[i] = (Coord[i] - x0) * ca - (Coord[i + 1] - y0) * sa + x0;
                tmpCoord[i + 1] = (Coord[i] - x0) * sa + (Coord[i + 1] - y0) * ca + y0;
            }
            tmpCoord.CopyTo(Coord, 0);
        }

        public override bool Equals(object obj)
        {
            if ((object)this == obj) return true;

            if (obj == null || this.GetType() != obj.GetType()) return false;

            Line tmpObj = (Line)obj;
            return X == tmpObj.X && Y == tmpObj.Y && X2 == tmpObj.X2 && Y2 == tmpObj.Y2;
        }

        public override int GetHashCode()
        {
            return (X, Y, X2, Y2, Coord).GetHashCode();
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
        public ColoredLine() { }
        public ColoredLine(string color)
        {
            Color = color;
        }
        public ColoredLine(float x1, float y1, float x2, float y2, string color) : base(x1, y1, x2, y2)
        {
            Color = color;
        }

        public override bool Equals(object obj)
        {
            if ((object)this == obj) return true;

            if (obj == null || this.GetType() != obj.GetType()) return false;

            ColoredLine tmpObj = (ColoredLine)obj;
            return X == tmpObj.X && Y == tmpObj.Y && X2 == tmpObj.X2
                                 && Y2 == tmpObj.Y2 && Color == tmpObj.Color;
        }
        public override int GetHashCode()
        {
            return (X, Y, X2, Y2, Coord, Color).GetHashCode();
        }

        public override string Info()
        {
            return base.Info() + ". Цвет " + Color;
        }

    }

    class PolyLine : Line
    {
        float[] coords;
        int length;
        public PolyLine() {
            length = 4;
            coords = new float[] { 0, 0, 1, 1 };
            SetProperties();
        }

        private void SetProperties()
        {
            X = coords[0];
            Y = coords[1];
            X2 = coords[2];
            Y2 = coords[3];
        }
        public PolyLine(params float[] coord)
        {
            length = coord.Length;
            coords = new float[length];
            int f = 0;
            foreach (float i in coord)
            {
                coords[f++] = i;
            }
            SetProperties();
        }

        public override float[] Coord
        {
            get
            {
                return coords;
            }
            set
            {
                if(value.Length < 4)
                {
                    throw new Exception("В многоугольнике мининмум две вершины (отрезок)");
                }
                // вынести в общую функцию:
                length = value.Length;
                coords = new float[length];
                int f = 0;
                foreach (float i in value)
                {
                    coords[f++] = i;
                }
                SetProperties();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == (object)this) return true;

            if (obj == null || this.GetType() != obj.GetType()) return false;

            PolyLine tmpObj = (PolyLine)obj;
            if (length != tmpObj.Coord.Length) return false;

            bool isEqual = true;
            for (int i = 0; i < length; ++i)
            {
                if (coords[i] != tmpObj.Coord[i]) isEqual = false;
            }
            return isEqual;
        }

        public override int GetHashCode()
        {
            return (X, Y, X2, Y2, Coord).GetHashCode();
        }

        public override string Info()
        {
            string info = "";
            for (int i = 0; i < length / 2; ++i)
            {
                info += String.Format("x{0} = {1}, y{0} = {2}, ", i + 1, coords[2 * i], coords[2 * i + 1]);
            }
            return string.Format("Многоугольник (n = {0}) с координатами вершин: {1}",
                length / 2, info);
        }

        public void Scale(float x, float y)
        {
            for(int i = 0; i < length / 2; i+=2)
            {
                coords[i] *= x;
                coords[i+1] *= y;
            }
        }
    }
}
