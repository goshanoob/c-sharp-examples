using System;

/* Класс Sets описыват математическое множество элементов. 
 * Метод Push() - возвращает новое множество, 
 * добавляя к текущему произвольное количество элементов, переданных в качестве параметров.
 
 */

namespace lab8
{
    class Sets
    {
        object[] set; // поле для хранения множества
        public int Length { get; } // свойство длины множества
        
        public Sets()
        {
            set = new object[0];
        }

        public Sets(params object[] set)
        {
            set = RemoveDuplicate(set);
            Length = set.Length;
            this.set = new object[Length];
            for (int i = 0; i < Length; i++)
            {
                this.set[i] = set[i];
            }
        }

        public Sets Push(params object[] set)
        {
            set = RemoveDuplicate(set);
            object[] comboMas = new object[Length + set.Length];
            this.set.CopyTo(comboMas, 0);
            set.CopyTo(comboMas, Length);
            Sets newSet = new Sets(comboMas);
            return newSet;
        }

        // объединение множеств
        public static Sets operator +(Sets a, Sets b)
        {
            return new Sets(a.set).Push(b.set);
        }

        public static Sets operator +(object a, Sets b)
        {
            return new Sets(a).Push(b.set);
        }
        public static Sets operator +(Sets a, object b)
        {
            return new Sets(a.set).Push(b);
        }
        public static Sets operator -(Sets a, object b)
        {

            return new Sets(a.Delete(b).set);
        }

        // разность множеств
        public static Sets operator -(Sets a, Sets b)
        {
            return new Sets(a.Delete(b.set).set);
        }

        public object this[int i]
        {
            get
            {
                if (i < 0 || i >= Length)
                {
                    throw new IndexOutOfRangeException("Индекс за границами множества");
                }
                return set[i];
            }
            set
            {
                set[i] = value;
            }
        }

        public Sets Delete(params object[] elems)
        {
            int count = 0; // количество элементов, которые должны покинуть множество
            object[] newMas; // массив для хранения нового множества
            foreach (object i in elems)
            {
                if (Array.IndexOf(set, i) != -1)
                {
                    ++count;
                }
            }

            if (count == 0) return this;
            
            newMas = new object[Length - count];
            for (int i = 0, f = 0; i < Length; i++)
            {
                if (Array.IndexOf(elems, set[i]) == -1)
                {
                    newMas[f++] = set[i];
                }
            }
            return new Sets(newMas);
        }

        // пересечение множеств
        public Sets Intersection(Sets a)
        {
            int count = 0, f = 0;
            foreach (object i in set)
            {
                if (Array.IndexOf(a.set, i) != -1)
                {
                    ++count;
                }
            }

            object[] newMas = new object[count];
            foreach (object i in set)
            {
                if (Array.IndexOf(a.set, i) != -1)
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
                    if (a[i] == a[j]) // не выполнится для  арифметических типов
                    {
                        a[j] = null;
                        ++count;
                    }
                }
            }

            if (count == 0) return a;

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

        /*

        string[] stringSet; // поле для хранения строкового множества
        double[] realSet; // поле для хранения множества вещественных чисел 

        public Sets() 
        {
            stringSet = new string[0];
            realSet = new double[0];
        }

        public Sets(params string[] set)
        {
            Length = set.Length;
            stringSet = new string[Length];
            Type = "string";
            for (int i = 0; i < Length; i++)
            {
                stringSet[i] = set[i];
            }
        }

        public Sets(params double[] set)
        {
            Length = set.Length;
            realSet = new double[Length];
            Type = "real";
            for (int i = 0; i < Length; i++)
            {
                realSet[i] = set[i];
            }
        }

        public Sets Push(params string[] set)
        {
            string[] comboMas = new string[Length + set.Length];
            stringSet.CopyTo(comboMas, 0);
            set.CopyTo(comboMas, Length);

            Sets newSet = new Sets(comboMas);
            return newSet;
        }

        public Sets Push(params double[] set)
        {
            double[] comboMas = new double[Length + set.Length];
            realSet.CopyTo(comboMas, 0);
            set.CopyTo(comboMas, set.Length);

            Sets newSet = new Sets(comboMas);
            return newSet;
        }

        public static Sets operator + (Sets a, Sets b)
        {
            Sets newSet;
            if (a.Type != b.Type)
            {
                throw new Exception("Множества раличных типов нельзя объединить");
            }
            else if (a.Type == "string")
            {
                newSet = new Sets(a.stringSet).Push(b.stringSet);
            }
            else if (a.Type == "real")
            {
                newSet = new Sets(a.realSet).Push(b.realSet);
            }
            else
            {
                throw new Exception("Тип аргументов не поддреживается");
            }

            return newSet;
        }


        public static Sets operator + (string a, Sets b)
        {
            string[] comboMas = new string[b.Length + 1];
            comboMas[0] = a;
            b.stringSet.CopyTo(comboMas, 1);
            return new Sets(comboMas);
        }
        public static Sets operator + (Sets a, string b)
        {
            string[] comboMas = new string[a.Length + 1];
            a.stringSet.CopyTo(comboMas, 0);
            comboMas[a.Length] = b;
            return new Sets(comboMas);
        }

        public static Sets operator + (double a, Sets b)
        {
            double[] comboMas = new double[b.Length + 1];
            comboMas[0] = a;
            b.stringSet.CopyTo(comboMas, 1);
            return new Sets(comboMas);
        }
        public static Sets operator + (Sets a, double b)
        {
            double[] comboMas = new double[a.Length + 1];
            a.stringSet.CopyTo(comboMas, 0);
            comboMas[a.Length] = b;
            return new Sets(comboMas);
        }

                public object this[int i]
        {
            get
            {
                if (i < 0 || i >= Length)
                {
                    throw new IndexOutOfRangeException("Индекс за границами множества");
                }
                if(this.Type == "string")
                {
                    return stringSet[i];
                }
                return realSet[i];


            }
            set
            {
                if (this.Type == "string")
                {
                    stringSet[i] = (string)value;
                }
                if (this.Type == "real")
                {
                    realSet[i] = Convert.ToDouble(value);
                }
            }
        }

        public Sets Delete(params object[] elems)
        {
            int count = 0; // количество элементов, которые должны покинуть множество
            foreach (object i in elems)
            {
                if (Array.IndexOf(stringSet, i) != -1)
                {
                    ++count;
                }
            }
            if (Type == "string")
            {
                string[] newMas = new string[Length - count];
                for(int i = 0, f = 0; i < Length; i++)
                {
                    if (Array.IndexOf(elems, stringSet[i]) == -1)
                    {
                        newMas[f++] = stringSet[i];
                    }
                }
                return new Sets(newMas);
            }
            else
            {
                double[] newMas = new double[Length - count];
                for (int i = 0, f = 0; i < Length; i++)
                {
                    if (Array.IndexOf(elems, realSet[i]) == 0)
                    {
                        newMas[f++] = realSet[i];
                    }
                }
                return new Sets(newMas);
            }
        } 

         */


    }
}
