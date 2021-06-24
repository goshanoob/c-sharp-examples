namespace goshanoob.F1Prediction
{

    // Класс реализован для обработки резульатов гонок. Свойство RaceTitle идентифицирует гонку.
    // Свойства PracticePosition, QualificationPosition, RacePosition служат для сдоступа к номеру
    // позиции, которое занял гонщик на финише после крактик, квалификации, гонки. Метод GetTotalPoints()
    // возвращает суммарный результат после третьей практики, квалификации, гонки.
    internal class Result
    {

        public string RaceTitle { get; set; }
        public int PracticePosition { get; set; }
        public int QualificationPosition { get; set; }
        public int RacePosition { get; set; }
        public bool BestLab { get; set; }

        public int GetTotalPoints() => GetRacePoints() + QualificationPoints() + PracticePoints();
        public int GetRacePoints() => ConvertToPoints(RacePosition);
        public int QualificationPoints() => ConvertToPoints(QualificationPosition);
        public int PracticePoints() => ConvertToPoints(PracticePosition);
        

        private int ConvertToPoints(int position)
        {
            int points = 0;
            switch (position)
            {
                case 1: points = 25; break;
                case 2: points = 18; break;
                case 3: points = 15; break;
                case 4: points = 12; break;
                case 5: points = 10; break;
                case 6: points = 8; break;
                case 7: points = 6; break;
                case 8: points = 4; break;
                case 9: points = 2; break;
                case 10: points = 1; break;
            }
            if (BestLab)
                points++;
            return points;
        }
    }
}
