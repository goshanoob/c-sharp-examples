using System;
// Класс, реализующий треугольники. Класс имеет закрытые поля, соответствующие значениям уголов
// и сторон треугольника (сторона с номером n лежит напротив угла n). Определены три конструктора
// для создания треугольников по умолчанию (правильных), по длинам сторон 
// (углы и координаты вычисляются автоматически), через координаты верышин (длины сторон и величина углов
// вычисляются автоматически). Реализованы три закрытых метода для вычисления длин строн через координаты
// вершин, углов через длины сторон, координат вершин через длины строн. Свойсто SetLines позволяет изменить
// длины сторон без их проверки. Свойство SetCoords позволяет изменить координаты вершин. Для перемещения
// и вращения треугольника следует использовать методы SetTranslate() и SetRotate(). Определен метод
// для вывода информации о треугольниках, а так же отдельные свойства для полей класса.
internal class Triangle
{
    private string name;
    private double _angle1, _angle2, _angle3, _line1, _line2, _line3;
    private double[] _coord1 = new double[2], _coord2 = new double[2], _coord3 = new double[2];
    // Коэффициент для перевода в радианы.
    private const double gR = Math.PI / 180;
    // Коэффициент для перевода в градусы.
    private const double rG = 180 / Math.PI;
    public Triangle()
    {
        const double defaultAngle = 60;
        const double defaultLine = 10;
        const double defaultCoord = 5;
        name = "Треугольник";
        _angle1 = _angle2 = _angle3 = defaultAngle;
        _line1 = _line2 = _line3 = defaultLine;
        _coord1[0] = _coord1[1] = 0;
        _coord2[0] = defaultLine;
        _coord2[1] = 0;
        _coord3[0] = defaultCoord;
        _coord3[1] = defaultCoord * Math.Tan(defaultAngle * gR);
    }

    public Triangle(double line1, double line2, double line3)
    {
        if (line1 + line2 < line3 || line2 + line3 < line1 || line1 + line1 < line1)
        {
            throw new Exception("Ошибка при определении длин сторон треугольника");
        }
        this._line1 = line1;
        this._line2 = line2;
        this._line3 = line3;
        CalcAngles();
        CalcCoords();
    }
    public Triangle(double c1x, double c1y, double c2x, double c2y, double c3x, double c3y)
    {
        _coord1[0] = c1x;
        _coord1[1] = c1y;
        _coord2[0] = c2x;
        _coord2[1] = c2y;
        _coord3[0] = c3x;
        _coord3[1] = c3y;
        CalcLines();
        CalcAngles();
    }

    private void CalcLines()
    {
        _line1 = Math.Sqrt(Math.Pow(_coord3[0] - _coord2[0], 2) +
            Math.Pow(_coord3[1] - _coord2[1], 2));
        _line2 = Math.Sqrt(Math.Pow(_coord3[0] - _coord1[0], 2) +
            Math.Pow(_coord3[1] - _coord1[1], 2));
        _line3 = Math.Sqrt(Math.Pow(_coord2[0] - _coord1[0], 2) +
            Math.Pow(_coord2[1] - _coord1[1], 2));
    }

    private void CalcAngles()
    {
        TestLines();
        _angle1 = Math.Acos((_line2 * _line2 + _line3 * _line3 - _line1 * _line1) /
            (2 * _line2 * _line3));
        _angle2 = rG * Math.Asin(Math.Sin(_angle1) * _line2 / _line1);
        _angle1 = rG * _angle1;
        _angle3 = 180 - _angle2 - _angle1;
    }

    private void CalcCoords()
    {
        TestLines();
        if (_angle1 == 0 || _angle2 == 0 || _angle3 == 0)
        {
            CalcAngles();
        }
        _coord1[0] = _coord1[1] = _coord2[1] = 0;
        _coord2[0] = _line2;
        _coord3[0] = _line2 * Math.Cos(_angle1 * gR);
        _coord3[1] = _line2 * Math.Sin(_angle1 * gR);
    }

    private void TestLines()
    {
        if (_line1 == 0 || _line2 == 0 || _line3 == 0)
        {
            throw new Exception("Нет возможности рассчитать углы треугольника (задайте длины сторон)");
        }
    }

    public double[] SetLines
    {
        set
        {
            _line1 = value[0];
            _line2 = value[1];
            _line3 = value[2];
            CalcAngles();
            CalcCoords();
        }
    }
    public double[] SetCoords
    {
        set
        {
            _coord1[0] = value[0]; _coord1[1] = value[1];
            _coord2[0] = value[2]; _coord2[1] = value[3];
            _coord3[0] = value[4]; _coord3[1] = value[5];
            CalcLines();
            CalcAngles();
        }
    }

    public double[,] SetTranslate(double x, double y)
    {
        _coord1[0] += x;
        _coord1[1] += y;
        _coord2[0] += x;
        _coord2[1] += y;
        _coord3[0] += x;
        _coord3[1] += y;
        return new double[3, 2]{ { _coord1[0], _coord1[1] },
                                { _coord2[0], _coord2[1] },
                                { _coord3[0], _coord3[1] } };
    }

    public double[,] SetRotate(double x, double y, double alpha)
    {
        double sa = Math.Sin(gR * alpha), ca = Math.Cos(gR * alpha),
            x1, y1, x2, y2, x3, y3;
        SetTranslate(-x, -y);
        x1 = _coord1[0]; y1 = _coord1[1];
        x2 = _coord2[0]; y2 = _coord2[1];
        x3 = _coord3[0]; y3 = _coord3[1];
        _coord1[0] = x1 * ca - y1 * sa;
        _coord1[1] = x1 * sa + y1 * ca;
        _coord2[0] = x2 * ca - y2 * sa;
        _coord2[1] = x2 * sa + y2 * ca;
        _coord3[0] = x3 * ca - y3 * sa;
        _coord3[1] = x3 * sa + y3 * ca;
        SetTranslate(x, y);
        return new double[,]{ { _coord1[0], _coord1[1] },
                              { _coord2[0], _coord2[1] },
                              { _coord3[0], _coord3[1] } };
    }

    public void showInfo()
    {
        Console.WriteLine("Информации о треугольнике \"{0}\": \n " +
            "Угол 1 равен {1} градусов, угол 2 равен {2} градусов, угол 3 равен {3} градусов; \n" +
            "Сторона 1 равна {4} попугаев, сторона 2 равна {5} попугаев, сторона 3 равна {6} попугаев; \n" +
            "Координаты вершин: {7}; {8}; {9}.",
            name, _angle1, _angle2, _angle3, _line1, _line2, _line3,
            _coord1[0].ToString() + ", " + _coord1[1].ToString(),
            _coord2[0].ToString() + ", " + _coord2[1].ToString(),
            _coord3[0].ToString() + ", " + _coord3[1].ToString());
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string getCoord
    {
        get
        {
            return _coord1.ToString(); ;
        }
    }

    public string getLines
    {
        get
        {
            return _line1 + "cm X" + _line2 + "cm X" + _line3 + "cm";
        }
    }

    public string getAngles
    {
        get
        {
            return _angle1 + "grad X" + _angle2 + "grad X" + _angle3 + "grad";
        }
    }
}