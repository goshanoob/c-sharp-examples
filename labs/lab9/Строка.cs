using System;

namespace lab9
{
    class Строка
    {
        string str; // последовательность символов
        short length; // длина строки в байтах

        public Строка() { }
        public Строка(string st) { }
        public Строка(char symb) { }
        public short GetLength()
        {
            return length;
        }

        public void Clear()
        {
            str = "";
            length = 0;
        }



    }
    class Комплексное_число
    {
        string real;
        string image;
        public string complexNum
        {
            get
            {
                return real+"i"+image;
            }
        }

        public override bool Equals(object obj)
        {
            if ((object)this == obj) return true;

            if (obj == null || this.GetType() != obj.GetType()) return false;

            Комплексное_число tmp = (Комплексное_число)obj;
            return real.Replace("+", "") == tmp.real.Replace("+","") && image.Replace("+", "") == tmp.image.Replace("+", "");
        }

        public string GetSum(Комплексное_число a)
        {
            return (Double.Parse(real) + Double.Parse(a.real)).toString() +
                (Double.Parse(image) + Double.Parse(a.image)).toString();

        }
        public string GetMult(Комплексное_число a)
        {
            return (Double.Parse(real) * Double.Parse(a.real)).toString() +
                (Double.Parse(image) * Double.Parse(a.image)).toString();

        }
    }

}
