using System;
using System.Collections.Generic;
using System.Text;

namespace delegat
{
    class Fraction
    {
        protected int num, den;
        public Fraction()
        {
            num = 0;
            den = 0;
        }
        public Fraction(int num, int den)
        {
            this.num = num;
            this.den = den;
        }
        internal void SetValues(int firstInt, int nextInt)
        {
            num = firstInt;
            den = nextInt;
        }

        public override string ToString()
        {
            return $"{num}, {den}";
        }
    }
}
