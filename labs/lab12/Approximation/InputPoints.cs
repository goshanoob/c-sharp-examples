using System;

namespace Approximation
{
    class InputPoints
    {
        private const double _xn = 0.01; // левая точка отрезка определения фукнкций
        private const double _xk = 20; // правая точка отрезка определения фукнкций
        private const int _pointsCount = 50; // количество точек
        public string F1 { get; private set; } // прямая y = x
        public string F2 { get; private set; } // правая ветка параболы y = x^2
        public string F3 { get; private set; } // наутральный логарифм y = ln(x)
        public string F4 { get; private set; } // косинусоида y = cos(x)
        public InputPoints()
        {
            double delta = (_xk - _xn) / _pointsCount;
            double x = _xn;
            for (int i = 0; i < _pointsCount; ++i)
            {
                F1 += $"{x}\t{x}\n";
                F2 += $"{x}\t{x * x}\n";
                F3 += $"{x}\t{Math.Log(x)}\n";
                F4 += $"{x}\t{Math.Cos(x)}\n";
                x += delta;
            }
        }
    }
}
