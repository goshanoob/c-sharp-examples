using System;
using System.Collections;
namespace RectWindowsForms
{
    class Rect : IEnumerable
    {
        // Компоненты цвета в формате RGB (0 - отсутствие компонента, 1 - наличие).
        private byte[] _colors;
        // Сторона прямоугольника A.
        public double A { get; set; }
        // Сторона прямоугольника B.
        public double B { get; set; }
        public Rect()
        {
            A = 100;
            B = 50;
            _colors = new byte[] { 1, 0, 0 };
        }
        public Rect(double a, double b) : this()
        {
            A = a;
            B = b;
        }
        public Rect(double a, double b, byte[] colors) : this()
        {
            if (colors.Length != 3)
                throw new FormatException("Количество компонентов цвета должно равняться трем.");
            A = a;
            B = b;
            Array.Copy(colors, _colors, 3);
        }
        public int this[int i]
        {
            get
            {
                return _colors[i];
            }
            set
            {
                if (i > 2 || i < 0) throw new IndexOutOfRangeException("Цвет имеет только три состовляющие. Индекс принмает значения от 0 до 2");
                _colors[i] = (byte)value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 3; ++i)
            {
                yield return _colors[i];
            }
        }
    }
}
