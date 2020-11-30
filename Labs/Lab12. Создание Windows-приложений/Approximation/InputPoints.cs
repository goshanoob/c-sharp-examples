using System;

namespace Approximation
{
    // Класс для подготовки входных значений для тестирования.
    class InputPoints
    {
        // Левая точка отрезка определения фукнкций.
        private const double _xn = 0.01;
        // Правая точка отрезка определения фукнкций.
        private const double _xk = 20;
        // Количество точек.
        private const int _pointsCount = 50;
        // Прямая y = x.
        public string F1 { get; private set; }
        // Правая ветка параболы y = x^2.
        public string F2 { get; private set; }
        // Наутральный логарифм y = ln(x).
        public string F3 { get; private set; }
        // Косинусоида y = cos(x).
        public string F4 { get; private set; }
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
