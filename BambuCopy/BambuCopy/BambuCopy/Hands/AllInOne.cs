using System;
using System.Collections.Generic;
using System.Text;
using BambuCopy.Classes;

namespace BambuCopy
{
    class AllInOne : Hand
    {
        AllInOne()
        {
            Name = "All In One";
            Scoring = 1;
            NumOfBadCards = 0;
            Score = new List<int>() { 0, 0, 0, 0 };
        }


    }
}
