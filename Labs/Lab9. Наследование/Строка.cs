namespace lab9
{
    internal class Строка
    {
        // Последовательность символов.
        private string _str;
        // Длина строки в байтах.
        private short _length;

        public Строка() { }
        public short GetLength()
        {
            return _length;
        }

        public void Clear()
        {
            _str = "";
            _length = 0;
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
                return $"{real}i{image}";
            }
        }

        public override bool Equals(object obj)
        {
            if ((object)this == obj) return true;

            if (obj == null || this.GetType() != obj.GetType()) return false;

            Комплексное_число tmp = (Комплексное_число)obj;
            return real.Replace("+", "") == tmp.real.Replace("+", "") && image.Replace("+", "") == tmp.image.Replace("+", "");
        }

        public string GetSum(Комплексное_число a)
        {
            return (double.Parse(real) + double.Parse(a.real)).ToString() + "i" +
                (double.Parse(image) + double.Parse(a.image)).ToString();

        }
        public string GetMult(Комплексное_число a)
        {
            return (double.Parse(real) * double.Parse(a.real)).ToString() + "i" +
                (double.Parse(image) * double.Parse(a.image)).ToString();
        }
    }
}
