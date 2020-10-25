using Microsoft.VisualBasic.CompilerServices;
using System;

/* Класс, реализующий вектор. */

namespace lab8
{
    class Vector
    {
        int[] vec;
        public int Length { get; }
        public Vector(int size)
        {
            vec = new int[size];
            Length = size;
        }

        // метод для доступа к элементам вектора
        public int GetValue(int i)
        {
            TestEdge(i);
            return vec[i];
        }

        // индексадор для доступа к элементам вектора
        public int this[int i]
        {
            get
            {
                TestEdge(i);
                return vec[i];
            }

            set
            {
                TestEdge(i);
                vec[i] = value;
            }
        }

        public string PrintValue(int i)
        {
            TestEdge(i);
            return String.Format("Элемент {0} вектора равен {1}", i, vec[i]);
        }
        public string PrintVector()
        {
            string str = "";
            foreach(int i in vec)
            {
                str += "\t" + i;
            }
            return str;
        }

        private void TestEdge(int i)
        {
            if (i >= vec.Length || i < 0)
            {
                throw new Exception("Индекс за границами вектора");
            }
        }

        // перегрузка опреаций с вектором
        public static Vector operator + (Vector a, Vector b)
        {
            int len1 = a.Length;
            int len2 = b.Length;
            if(len1 != len2)
            {
                throw new Exception("Векторы имеют разную размерность, сложение невозможно");
            }
            Vector newVec = new Vector(len1);
            for(int i = 0; i < len2; i++)
            {
                newVec.vec[i] = a.vec[i] + b.vec[i];
            }
            return newVec;
        }

    }
}
