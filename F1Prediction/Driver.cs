using System.Collections.Generic;

namespace goshanoob.F1Prediction
{
    internal class Driver
    {
        public string Name { get; set; }
        public List<Result> Results { get; set; }
        public int GetTotalResult()
        {
            int sum = 0;
            foreach (Result result in Results)
            {
                sum += result.GetTotalPoints();
            }
            return sum;
        }
    }
}
