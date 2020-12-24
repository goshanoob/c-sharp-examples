using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;

namespace Blood_Pressure_and_Weather
{
    // Класс Graph для построения графиков, заданных при помощи множества точек, соединенных отрезками.
    // Используется библиотека OxyPlot.
    // Свойство CurveGraph описывает модель данных графика. Данная модель используется в разметке WPF.
    // Свойство Points доступно для задания точек графика.
    // Перечисленные свойства имеют занчения по умполчиню, которые используются в конструкторе для построения графика прямой,
    // соединяющей точки (0,0) и (20,100).
    // Метод RefreshGraph() перерисовывает текущий график, используя совойство Points. Пользователь класса
    // может изменить совойство Points и перестроить график по новым точкам.
    // Метод DrawGraphs() перегружен дважды и используется для построения произвольного количества линий на
    // одном графике, переданных в качестве аргументов.
    // Метод SetLines() подзволяет визуально разделить значения графика по горизонтальной оси при помощи вертикальных линий.

    internal class Graph
    {
        public PlotModel CurveGraph { get; set; } = new PlotModel { Title = "Новый график" };
        public List<double> Points { get; set; } = new List<double> { 0, 100 };
        public Graph()
        {
            /* 
            LineSeries series = new LineSeries { Title = "Систолическое", MarkerType = MarkerType.Square };
            LineSeries series2 = new LineSeries { Title = "Диастолическое", MarkerType = MarkerType.Square };
            grath.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            */
            CurveGraph.Series.Add(GetData());
            FunctionSeries GetData()
            {
                FunctionSeries serie = new FunctionSeries();
                int x = 0;
                DataPoint point;
                foreach (double value in Points)
                {
                    point = new DataPoint(x, value);
                    serie.Points.Add(point);
                    x += 20;
                }
                return serie;
            }
        }
        public void RefreshGraph()
        {
            CurveGraph.Series.Clear();
            FunctionSeries serie = new FunctionSeries();
            int x = 0;
            foreach (double value in Points)
            {
                serie.Points.Add(new DataPoint(x, value));
                x += 10;
            }
            CurveGraph.Series.Add(serie);
            CurveGraph.Title = "Новый график";
            CurveGraph.InvalidatePlot(true);
        }

        public void DrawGraphs(string title = "Графики", params double[][] curves)
        {
            CurveGraph.Title = title;
            DrawGraphs(curves);
        }

        public void DrawGraphs(params double[][] curves)
        {
            CurveGraph.Series.Clear();
            FunctionSeries[] serie = new FunctionSeries[curves.Length];
            int x = 0, i = 0;
            foreach (double[] curve in curves)
            {
                x = 0;
                serie[i] = new FunctionSeries();
                foreach (double value in curve)
                {
                    serie[i].Points.Add(new DataPoint(x, value));
                    x += 10;
                }
                CurveGraph.Series.Add(serie[i++]);
            }
            CurveGraph.InvalidatePlot(true);
        }

        public void DrawGraphsXY(double[] x, double[] y)
        {
            CurveGraph.Series.Clear();
            ScatterSeries serie = new ScatterSeries();
            for(int i = 0; i < x.Length; ++i)
            {
                serie.Points.Add(new ScatterPoint(x[i], y[i]));
            }
            CurveGraph.Series.Add(serie);
            CurveGraph.InvalidatePlot(true);
        }

        private void SetLines()
        {
            throw new NotImplementedException("Метод не реализован");
        }
    }
}