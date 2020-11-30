using System;

// Класс Sets описыват математическое множество элементов. 
// Метод Push() - возвращает новое множество, 
// добавляя к текущему произвольное количество элементов, переданных в качестве параметров.

namespace lab8
{
    internal class Sets
    {
        // Поле для хранения множества.
        private object[] _set;
        // Свойство возвращающее кол-во элементов множества.
        public int Length { get; }

        public Sets()
        {
            _set = new object[0];
        }

        public Sets(params object[] set)
        {
            set = RemoveDuplicate(set);
            Length = set.Length;
            _set = new object[Length];
            for (int i = 0; i < Length; i++)
            {
                _set[i] = set[i];
            }
        }

        public Sets Push(params object[] set)
        {
            set = RemoveDuplicate(set);
            object[] comboMas = new object[Length + set.Length];
            _set.CopyTo(comboMas, 0);
            set.CopyTo(comboMas, Length);
            Sets newSet = new Sets(comboMas);
            return newSet;
        }

        // Объединение множеств.
        public static Sets operator +(Sets a, Sets b)
        {
            return new Sets(a._set).Push(b._set);
        }

        public static Sets operator +(object a, Sets b)
        {
            return new Sets(a).Push(b._set);
        }
        public static Sets operator +(Sets a, object b)
        {
            return new Sets(a._set).Push(b);
        }
        public static Sets operator -(Sets a, object b)
        {

            return new Sets(a.Delete(b)._set);
        }

        // Разность множеств.
        public static Sets operator -(Sets a, Sets b)
        {
            return new Sets(a.Delete(b._set)._set);
        }

        public object this[int i]
        {
            get
            {
                if (i < 0 || i >= Length)
                {
                    throw new IndexOutOfRangeException("Индекс за границами множества");
                }
                return _set[i];
            }
            set
            {
                _set[i] = value;
            }
        }

        public Sets Delete(params object[] elems)
        {
            // Количество элементов, которые должны покинуть множество.
            int count = 0;
            // Массив для хранения нового множества.
            object[] newMas;
            foreach (object i in elems)
            {
                if (Array.IndexOf(_set, i) != -1)
                {
                    ++count;
                }
            }
            if (count == 0)
                return this;
            newMas = new object[Length - count];
            for (int i = 0, f = 0; i < Length; i++)
            {
                if (Array.IndexOf(elems, _set[i]) == -1)
                {
                    newMas[f++] = _set[i];
                }
            }
            return new Sets(newMas);
        }

        // Пересечение множеств.
        public Sets Intersection(Sets a)
        {
            int count = 0, f = 0;
            foreach (object i in _set)
            {
                if (Array.IndexOf(a._set, i) != -1)
                {
                    ++count;
                }
            }

            object[] newMas = new object[count];
            foreach (object i in _set)
            {
                if (Array.IndexOf(a._set, i) != -1)
                {
                    newMas[f++] = i;
                }
            }
            return new Sets(newMas);
        }

        private object[] RemoveDuplicate(object[] a)
        {
            int count = 0, len = a.Length, f = 0;
            for (int i = 0; i < len; ++i)
            {
                if (a[i] == null) continue;
                for (int j = i + 1; j < len; ++j)
                {
                    // Следующая операция не выполнится для  арифметических типов.
                    if (a[i] == a[j])
                    {
                        a[j] = null;
                        ++count;
                    }
                }
            }
            if (count == 0)
                return a;
            object[] newMas = new object[len - count];
            foreach (object i in a)
            {
                if (Array.IndexOf(newMas, i) == -1 && i != null)
                {
                    newMas[f++] = i;
                }
            }
            return newMas;
        }
    }
}
