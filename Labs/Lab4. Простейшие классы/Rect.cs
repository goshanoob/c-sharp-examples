using System;
class Rect
{
    // координаты вершин, обходятся по часовой стрелке с левого нижнего угла;
    // длины сторон: ширина и высота
    double[,] vertices = new double[4, 2];
    double[] edges = new double[2];

    public Rect()
    {
        const byte defaultCoord = 10;
        vertices[0,0] = vertices[0,1] = vertices[1,1] = vertices[3,0] = 0;
        vertices[1,0] = vertices[2,0] = vertices[2,1] = vertices[3,1] = defaultCoord;
        edges[0] = edges[1] = 10;
    }

    public Rect(double x, double y, double width, double height)
    {
        // x, y - координаты левого нижнего угла прямоугольника; 
        // width, height - ширина (протяженность вдоль оси X) и высота прямоугольника.
        SetRectProperties(x, y, width, height);
    }

    private void SetRectProperties(double x, double y, double width, double height)
    {
        vertices[0, 0] = x; vertices[0, 1] = y;
        vertices[1, 0] = x + width; vertices[1, 1] = y;
        vertices[2, 0] = x + width; vertices[2, 1] = y + height;
        vertices[3, 0] = x; vertices[3, 1] = y + height;
        edges[0] = width;
        edges[1] = height;
    }

    public Rect(double[] vert)
    {
        if(vert.Length != 8)
        {
            throw new Exception("Неверное количество координат вершин в конструкторе прямоугольника");
        }
        for(byte i = 0, k = 0; i < 4; ++i, k+=2)
        {
            vertices[i, 0] = vert[k];
            vertices[i, 1] = vert[k+1];
        }
    }

    public void SetScale(double rx, double ry)
    {
        SetRectProperties(vertices[0, 0], vertices[0, 1], rx * edges[0], ry * edges[1]);
    }

    public void SetScale(double rxy)
    {
        SetRectProperties(vertices[0, 0], vertices[0, 1], rxy * edges[0], rxy * edges[1]);
    }

    public double[,] GiveShareRect()
    {

        return new double[4,2];
    }
    /*
    public Rect GiveShareRect2()
    {
        return new Rect(new double[8] { vertices[0,], vertices[,],
                                        vertices[,], vertices[,],
                                        vertices[,], vertices[,],
                                        vertices[,], vertices[,] });
    }*/

}

