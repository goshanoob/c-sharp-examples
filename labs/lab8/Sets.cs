using System;

/* Класс Sets описыват математическое множество элементов. 
 * Метод Push() - возвращает новое множество, 
 * добавляя к текущему произвольное количество элементов, переданных в качестве параметров.
 
 */

namespace lab8
{
    class Sets
    {
        string[] stringSet; // поле для хранения строкового множества
        double[] realSet; // поле для хранения множества вещественных чисел 
        public int Length { get; } // свойство длины множества
        public string Type { get; } // свойство типа множества (строковый или вещественный) - лучше сделать перечисление

        public Sets() 
        {
            stringSet = new string[0];
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


    }
}
