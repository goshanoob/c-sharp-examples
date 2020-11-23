using System;

/* Класс для создания поля игры в пятнашки. Свойство TagMatrix содержит карту расположения пятнашек.
 * Определен конструктор, располагающий пятнашки в правильной последовательности. Правильной назовем
 * последовательность, в которой все элементы расположены по возрастанию от меньшего к большему, но последний
 * элемент имеет номер 0. 
 * Метод SetMove() перемещает пятнашку в пустую клетку, если такой ход возможен. Метод Shaffle() перемешивает 
 * игровое поле. Метод TestResult() проверяет последовательность пятнашек на правильность.
 */
namespace Pyatnashki
{
    internal class Tags
    {
        private int _tagsCount; // количество пятнашей (тегов)
        private int _zeroTagRow; // номер строки пустого поля
        private int _zeroTagCol; // номер столбца пустого поля
        private int _rowCount, _colCount; // количество строк и столбцов игрового поля
        public int[,] TagMatrix { get; private set; }
        public Tags(int i, int j)
        {
            _rowCount = i;
            _colCount = j;
            _tagsCount = i * j;
            TagMatrix = new int[i, j];
            _zeroTagRow = i - 1;
            _zeroTagCol = j - 1;
            for (int k = 0; k < _tagsCount; ++k)
            {
                TagMatrix.SetValue(k + 1, k / i, k % j);
            }
            TagMatrix[i - 1, j - 1] = 0;
        }

        public void SetMove(int i, int j)
        {
            if (IsRealMove(i, j))
            {
                TagMatrix[_zeroTagRow, _zeroTagCol] = TagMatrix[i, j];
                TagMatrix[i, j] = 0;
                _zeroTagRow = i;
                _zeroTagCol = j;
            }
        }

        private bool IsRealMove(int i, int j)
        { 
            // проверка, возможен ли ход
            int dRow = Math.Abs(_zeroTagRow - i);
            int dCol = Math.Abs(_zeroTagCol - j);
            if (dRow == 0 && dCol == 1 || dRow == 1 && dCol == 0)
                return true;
            return false;
        }
        public void Shaffle()
        {
            Random rnd = new Random();
            int firstTag = 1;
            for (int i = 0; i < _rowCount; ++i)
                for (int j = 0; j < _colCount - 1; ++j)
                {
                    int position = rnd.Next(firstTag, _tagsCount - 1);
                    int positionRow = position / _rowCount; // строка случайной пятнаяшки
                    int positionCol = position % _colCount; // столбец случайной пятнаяшки

                    int tmp = TagMatrix[positionRow, positionCol];
                    TagMatrix[positionRow, positionCol] = TagMatrix[i, j];
                    TagMatrix[i, j] = tmp;

                    ++firstTag;
                }
        }
        public bool TestResult()
        {
            bool isRightResult = true;
            int k = 1;
            foreach(int i in TagMatrix)
            {
                if(k == _tagsCount) 
                    return isRightResult;
                if (i != k++)
                {
                    isRightResult = false;
                    break;
                }
            }
            return isRightResult;
        }
    }
}

