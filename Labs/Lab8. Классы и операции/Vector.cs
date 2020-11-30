using System;

// Класс, реализующий вектор целочисленных значений (int). Единственный конструктор позволяет создать вектор 
// заданной длины (количество элементов). Свойство Length возвращает длину вектора.
// Для доступа к элементам вектора по индексу реализован индексадор и отдельный метод.
// Методы PrintVector() и PrintValue() возвращают значения строкового типа, содержащие
// все элементы вектора либо одно значение по его индексу. Закрытый метод проверяет
// допустимость переданных методам индексов и выбрасывает исключения в случае выхода за границы вектора.
// В классе перегружены операции для поэлементного сложения векторов, умножения вектора
// на число (или числа на вектор), деления вектора на скаляр. В качестве множителя (делителя)
// допускаются вещественные значения, в этом случае их дробная часть отбрасывается. Результат
// любой операции - целое число.

namespace lab8
{
    internal class Vector
    {
        private int[] _vec;
        public int Length { get; }
        public Vector(int size)
        {
            _vec = new int[size];
            Length = size;
        }

        // Метод для доступа к элементам вектора.
        public int GetValue(int i)
        {
            TestEdge(i);
            return _vec[i];
        }

        // Индексадор для доступа к элементам вектора.
        public int this[int i]
        {
            get
            {
                TestEdge(i);
                return _vec[i];
            }
            set
            {
                TestEdge(i);
                _vec[i] = value;
            }
        }

        public string PrintValue(int i)
        {
            TestEdge(i);
            return String.Format("Элемент {0} вектора равен {1}", i, _vec[i]);
        }
        public string PrintVector()
        {
            string str = "";
            foreach (int i in _vec)
            {
                str += "\t" + i;
            }
            return str;
        }

        private void TestEdge(int i)
        {
            if (i >= _vec.Length || i < 0)
            {
                throw new ArgumentOutOfRangeException("Индекс за границами вектора");
            }
        }

        // перегрузка операций с вектором
        public static Vector operator +(Vector a, Vector b)
        {
            int len1 = a.Length;
            int len2 = b.Length;
            if (len1 != len2)
            {
                throw new Exception("Векторы имеют разную размерность, сложение невозможно");
            }
            Vector newVec = new Vector(len1);
            for (int i = 0; i < len2; i++)
            {
                newVec._vec[i] = a._vec[i] + b._vec[i];
            }
            return newVec;
        }

        public static Vector operator *(double a, Vector b)
        {
            int len = b.Length;
            Vector newVec = new Vector(len);
            for (int i = 0; i < len; ++i)
            {
                newVec._vec[i] = b._vec[i] * (int)a; // дробная часть отбрасывается
            }
            return newVec;
        }

        public static Vector operator *(Vector b, double a)
        {
            int len = b.Length;
            Vector newVec = new Vector(len);
            for (int i = 0; i < len; ++i)
            {
                newVec._vec[i] = b._vec[i] * (int)a;
            }
            return newVec;
        }

        public static Vector operator /(Vector a, double b)
        {
            int len = a.Length;
            Vector newVec = new Vector(len);
            for (int i = 0; i < len; ++i)
            {
                newVec._vec[i] = a._vec[i] / (int)b;
            }
            return newVec;
        }
    }
}