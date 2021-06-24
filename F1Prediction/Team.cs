using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goshanoob.F1Prediction
{
    internal class Team
    {
        public List<Driver> Drivers { get; set; }
        public string Chassis { get; set; }
        public string Engine { get; set; }

        public int GetTotalResult()
        {
            return 0;
        }
    }
}
