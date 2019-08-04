using System;
using System.Collections.Generic;
using System.Text;

namespace BambuCopy
{
    class Domino : Hand
    {
        Domino()
        {
            Name = "Domino";
            Scoring = 10;
            NumOfBadCards = 2;
            Score = new List<int>() { 0, 0, 0, 0 };
        }
    }
}
