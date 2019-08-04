using System;
using System.Collections.Generic;
using System.Text;

namespace BambuCopy
{
    class Tricks : Hand
    {
        Tricks()
        {
            Name = "Tricks";
            Scoring = -1;
            NumOfBadCards = 8;
            Score = new List<int>() { 0, 0, 0, 0 };
        }
    }
}
