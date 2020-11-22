using System;

namespace Pyatnashki
{
    internal class Tags
    {
        private int _tagsCount;
        //private int[,] _tagMatrix;
        private int _zeroTag;
        private int _zeroTagRow;
        private int _zeroTagCol;
        private int _i, _j;

        public int[,] TagMatrix { get; private set; }

        public Tags(int i, int j)
        {
            _i = i;
            _j = j;
            _tagsCount = i * j;
            TagMatrix = new int[i, j];
            _zeroTag = _tagsCount - 1;
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

        public bool IsRealMove(int i, int j)
        {
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
            for (int i = 0; i < _i; ++i)
                for (int j = 0; j < _j - 1; ++j)
                {
                    int position = rnd.Next(firstTag, _tagsCount - 1);
                    int positionRow = position / _i; // строка случайной пятнаяшки
                    int positionCol = position % _j; // столбец случайной пятнаяшки

                    int tmp = TagMatrix[positionRow, positionCol];
                    TagMatrix[positionRow, positionCol] = TagMatrix[i, j];
                    TagMatrix[i, j] = tmp;

                    ++firstTag;
                }
        }
    }
}

