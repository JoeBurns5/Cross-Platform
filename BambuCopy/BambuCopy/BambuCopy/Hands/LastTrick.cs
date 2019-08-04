using System;
using System.Collections.Generic;
using System.Text;

namespace BambuCopy
{
    class LastTrick : Hand
    {
        LastTrick()
        {
            Name = "Last Trick";
            Scoring = -8;
            NumOfBadCards = 1;
            Score = new List<int>() { 0, 0, 0, 0 };
        }
    }
}
