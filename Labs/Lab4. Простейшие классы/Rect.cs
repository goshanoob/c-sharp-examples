using System;
internal class Rect
{
    // Координаты вершин, обходятся по часовой стрелке с левого нижнего угла.
    private double[,] _vertices = new double[4, 2];
    // Длины сторон: ширина и высота.
    private double[] _edges = new double[2];

    public Rect()
    {
        const byte defaultCoord = 10;
        _vertices[0, 0] = _vertices[0, 1] = _vertices[1, 1] = _vertices[3, 0] = 0;
        _vertices[1, 0] = _vertices[2, 0] = _vertices[2, 1] = _vertices[3, 1] = defaultCoord;
        _edges[0] = _edges[1] = 10;
    }

    public Rect(double x, double y, double width, double height)
    {
        // x, y - координаты левого нижнего угла прямоугольника; 
        // width, height - ширина (протяженность вдоль оси X) и высота прямоугольника.
        SetRectProperties(x, y, width, height);
    }

    private void SetRectProperties(double x, double y, double width, double height)
    {
        _vertices[0, 0] = x; _vertices[0, 1] = y;
        _vertices[1, 0] = x + width; _vertices[1, 1] = y;
        _vertices[2, 0] = x + width; _vertices[2, 1] = y + height;
        _vertices[3, 0] = x; _vertices[3, 1] = y + height;
        _edges[0] = width;
        _edges[1] = height;
    }

    public Rect(double[] vert)
    {
        if (vert.Length != 8)
        {
            throw new Exception("Неверное количество координат вершин в конструкторе прямоугольника");
        }
        for (byte i = 0, k = 0; i < 4; ++i, k += 2)
        {
            _vertices[i, 0] = vert[k];
            _vertices[i, 1] = vert[k + 1];
        }
        _edges[0] = Math.Abs(_vertices[0, 0] - _vertices[3, 0]);
        _edges[1] = Math.Abs(_vertices[0, 1] - _vertices[1, 1]);
    }

    public void SetScale(double rx, double ry)
    {
        SetRectProperties(_vertices[0, 0], _vertices[0, 1], rx * _edges[0], ry * _edges[1]);
    }

    public void SetScale(double rxy)
    {
        SetRectProperties(_vertices[0, 0], _vertices[0, 1], rxy * _edges[0], rxy * _edges[1]);
    }

    public double[,] GetVertices()
    {
        return _vertices;
    }

    public double[,] GiveShareRect()
    {
        throw new  NotImplementedException("Метод не реализован");
    }
}

