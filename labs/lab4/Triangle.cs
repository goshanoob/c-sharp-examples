using System;
/* Класс, реализующий треугольники. Класс имеет закрытые поля, соответствующие значениям уголов
 * и сторон треугольника (сторона с номером n лежит напротив угла n). Определены три конструктора
 * для создания треугольников по умолчанию (правильных), по длинам сторон 
 * (углы и координаты вычисляются автоматически), через координаты верышин (длины сторон и величина углов
 * вычисляются автоматически). Реализованы три закрытых метода для вычисления длин строн через координаты
 * вершин, углов через длины сторон, координат вершин через длины строн. Свойсто SetLines позволяет изменить
 * длины сторон без их проверки. Свойство SetCoords позволяет изменить координаты вершин. Для перемещения
 * и вращения треугольника следует использовать методы SetTranslate() и SetRotate(). Определен метод
 * для вывода информации о треугольниках, а также отдельные свойства для полей класса. */
class Triangle
{
    private string name;
    private double angle1, angle2, angle3, line1, line2, line3;
    double[] coord1 = new double[2], coord2 = new double[2], coord3 = new double[2];
    const double gR = Math.PI / 180; // для перевода в радианы
    const double rG = 180 / Math.PI; // для перевода в градусы
    public Triangle()
    {
        const double defaultAngle = 60;
        const double defaultLine = 10;
        const double defaultCoord = 5;
        name = "Треугольник";
        angle1 = angle2 = angle3 = defaultAngle;
        line1 = line2 = line3 = defaultLine;
        coord1[0] = coord1[1] = 0;
        coord2[0] = defaultLine;
        coord2[1] = 0;
        coord3[0] = defaultCoord;
        coord3[1] = defaultCoord * Math.Tan(defaultAngle * gR);
    }

    public Triangle(double line1, double line2, double line3)
    {
        if(line1 + line2 < line3 || line2 + line3 < line1 || line1 + line1  < line1 ){
            throw new Exception("Ошибка при определении длин сторон треугольника");
        }
        this.line1 = line1;
        this.line2 = line2;
        this.line3 = line3;
        CalcAngles();
        CalcCoords();
    }
    public Triangle(double c1x, double c1y, double c2x, double c2y, double c3x, double c3y)
    {
        coord1[0] = c1x;
        coord1[1] = c1y;
        coord2[0] = c2x;
        coord2[1] = c2y;
        coord3[0] = c3x;
        coord3[1] = c3y;
        CalcLines();
        CalcAngles();
    }

    private void CalcLines()
    {
        line1 = Math.Sqrt(Math.Pow(coord3[0] - coord2[0], 2) + 
            Math.Pow(coord3[1] - coord2[1], 2));
        line2 = Math.Sqrt(Math.Pow(coord3[0] - coord1[0], 2) +
            Math.Pow(coord3[1] - coord1[1], 2));
        line3 = Math.Sqrt(Math.Pow(coord2[0] - coord1[0], 2) +
            Math.Pow(coord2[1] - coord1[1], 2));
    }

    private void CalcAngles()
    {
        TestLines();
        angle1 = Math.Acos((line2 * line2 + line3 * line3 - line1 * line1) /
            (2 * line2 * line3));
        angle2 = rG * Math.Asin(Math.Sin(angle1) * line2 / line1);
        angle1 = rG * angle1;
        angle3 = 180 - angle2 - angle1;
    }

    private void CalcCoords()
    {
        TestLines();
        if (angle1 == 0 || angle2 == 0 || angle3 == 0)
        {
            CalcAngles();
        }
        coord1[0] = coord1[1] = coord2[1] = 0;
        coord2[0] = line2;
        coord3[0] = line2 * Math.Cos(angle1 * gR);
        coord3[1] = line2 * Math.Sin(angle1 * gR);
    }

    private void TestLines()
    {
        if (line1 == 0 || line2 == 0 || line3 == 0)
        {
            throw new Exception("Нет возможности рассчитать углы треугольника (задайте длины сторон)");
        }
    }

    public double[] SetLines
    {
        set
        {
            line1 = value[0];
            line2 = value[1];
            line3 = value[2];
            CalcAngles();
            CalcCoords();
        }
    }

    public double[] SetCoords
    {
        set
        {
            coord1[0] = value[0]; coord1[1] = value[1];
            coord2[0] = value[2]; coord2[1] = value[3];
            coord3[0] = value[4]; coord3[1] = value[5]; 
            CalcLines();
            CalcAngles();
        }
    }

    public double[,] SetTranslate(double x, double y)
    {
        coord1[0] += x;
        coord1[1] += y;
        coord2[0] += x;
        coord2[1] += y;
        coord3[0] += x;
        coord3[1] += y;
        return new double[3,2]{ { coord1[0], coord1[1] }, 
                                { coord2[0], coord2[1] }, 
                                { coord3[0], coord3[1] } }; 
    }

    public double[,] SetRotate(double x, double y, double alpha)
    {
        double sa = Math.Sin(gR * alpha), ca = Math.Cos(gR *  alpha), 
            x1, y1, x2, y2, x3, y3;
        SetTranslate(-x, -y);
        x1 = coord1[0]; y1 = coord1[1];
        x2 = coord2[0]; y2 = coord2[1];
        x3 = coord3[0]; y3 = coord3[1];
        coord1[0] = x1 * ca - y1 * sa;
        coord1[1] = x1 * sa + y1 * ca;
        coord2[0] = x2 * ca - y2 * sa;
        coord2[1] = x2 * sa + y2 * ca;
        coord3[0] = x3 * ca - y3 * sa;
        coord3[1] = x3 * sa + y3 * ca;
        SetTranslate(x, y);
        return new double[,]{ { coord1[0], coord1[1] }, 
                              { coord2[0], coord2[1] },
                              { coord3[0], coord3[1] } };
    }

    public void showInfo()
    {
        Console.WriteLine("Информации о треугольнике \"{0}\": \n " +
            "Угол 1 равен {1} градусов, угол 2 равен {2} градусов, угол 3 равен {3} градусов; \n" +
            "Сторона 1 равна {4} попугаев, сторона 2 равна {5} попугаев, сторона 3 равна {6} попугаев; \n" +
            "Координаты вершин: {7}; {8}; {9}.", 
            name, angle1, angle2, angle3, line1, line2, line3, 
            coord1[0].ToString()+ ", " + coord1[1].ToString(), 
            coord2[0].ToString() + ", " + coord2[1].ToString(),
            coord3[0].ToString() +", "+ coord3[1].ToString());
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
            return coord1.ToString(); ;
        }
    }

    public string getLines
    {
        get
        {
            return line1 + "cm X" + line2 + "cm X" + line3 + "cm";
        }
    }

    public string getAngles
    {
        get
        {
            return angle1 + "grad X" + angle2 + "grad X" + angle3 + "grad";
        }
    }

}