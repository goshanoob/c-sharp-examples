using System;
using System.Collections.Generic;
using System.Text;

namespace delegat
{
    class Fraction
    {
        protected int _num, _den;
        public Fraction()
        {
            _num = 0;
            _den = 0;
        }
        public Fraction(int num, int den)
        {
            _num = num;
            _den = den;
        }
        internal void SetValues(int firstInt, int nextInt)
        {
            _num = firstInt;
            _den = nextInt;
        }

        public override string ToString()
        {
            return $"{_num}, {_den}";
        }
    }
}
