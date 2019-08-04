using System;
using System.Collections.Generic;
using System.Text;

namespace BambuCopy
{
    class Queens : Hand
    {
        public Queens()
        {
            Name = "Queens";
            Scoring = -2;
            NumOfBadCards = 4;
            Score = new List<int>() { 0, 0, 0, 0 };

        }
    }
}
