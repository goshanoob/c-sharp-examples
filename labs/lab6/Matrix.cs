using System;

/* Класс, реализующий матрицы. Класс содержит конструктор по умолчанию, создающий матрицу 3х3 нулевых элементов.
 * Второй конструктор позволяют создать матрицу m на n и заполнить ее случайными числами. Третий конструктор 
 * следует использовать для определения матриц с конкретными значениями. */
public class Matrix
{
    const int m_ = 3, n_ = 3; // значениия m и n по умолчанию
    const int mn = -10, mx = 10; // значениия min и max по умолчанию

    ushort m, n; // размерность матрицы
    short[,] matrix; // прямоугольная матрицы
    public int Min { get; set; } = mn;
    public int Max { get; set; } = mx; // минимальное и максимальное значения элементов матрицы

    string sedloDigitString; // для хранения седловых точек в виде строки

    public Matrix()
    {
        m = m_;
        n = n_;
        Min = mn;
        Max = mx;
        matrix = new short[m, n];
    }

    public Matrix(ushort m, ushort n, int min = mn, int max = mx)
    {
        this.m = m;
        this.n = n;
        this.Min = min;
        this.Max = max;
        matrix = new short[m, n];
        GenerateRandomValues();
    }

    public Matrix(short[,] elems)
    {
        m = (ushort)elems.GetLength(0);
        n = (ushort)elems.GetLength(1);
        matrix = new short[m, n];
        /*
         вычислить свойства Min и Max
         */
        for (byte i = 0; i < m; ++i)
        {
            for (byte j = 0; j < n; ++j)
            {
                matrix[i, j] = elems[i, j];
            }
        }
    }

    public void GenerateRandomValues()
    {
        Random rnd = new Random();
        for (byte i = 0; i < m; ++i)
        {
            for (byte j = 0; j < n; ++j)
            {
                matrix[i, j] = (short)rnd.Next(Min, Max);
            }
        }
    }



    // метод поиска седловых точек

    public short[,] GetSedloDigit()
    {
        short[,] sedloDigit = new short[m * n, 2];
        short minInStr; // для хранения наименьшего значения в строке
        bool maxInCol; // для определения, является ли minInStr наибольшим в столбце
        int f = 0; // счетчик количества точек
        for (byte i = 0; i < m; ++i)
        {
            minInStr = matrix[i, 0];

            for (byte j = 0; j < n; ++j)
            {   // ищем значение наименьшего элемента в строке
                minInStr = minInStr > matrix[i, j] ? matrix[i, j] : minInStr;
                /*if (minInStr > matrix[i, j])
                {
                    minInStr = matrix[i, j];
                }*/
            }

            // ищем количество нименьших элементов в строке, если их несколько
            for (byte j = 0; j < n; ++j)
            {
                if (minInStr == matrix[i, j])
                {
                    maxInCol = true;
                    // проверяем, является ли элемент седловым, просматривая элементы столбца
                    for (byte k = 0; k < m; ++k)
                    {
                        if (minInStr < matrix[k, j])
                        {
                            maxInCol = false;
                            break;
                        }
                    }
                    if (maxInCol)
                    {
                        // нашли седловой элемент, добавляем в массив
                        sedloDigit[f, 0] = i;
                        sedloDigit[f++, 1] = j;
                        sedloDigitString += String.Format("Седловая точка матрицы номер {3}: строка {0}, солбец {1}, значение {2}\n", i + 1, j + 1, matrix[i, j], f);

                    }
                }
            }
        }

        return sedloDigit;
    }

    public string SedloDigitString
    {
        get
        {
            return sedloDigitString;
        }
    }


}
