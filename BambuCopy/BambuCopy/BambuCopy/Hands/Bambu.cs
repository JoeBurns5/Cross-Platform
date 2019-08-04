using System;
using System.Collections.Generic;
using System.Text;

namespace BambuCopy
{
    class Bambu : Hand

    {        
        public Bambu()
        {
            Name = "Bambu";
            Scoring = -8;
            NumOfBadCards = 1;
            Score = new List<int>() { 0, 0, 0, 0 };
        }
    }
}
