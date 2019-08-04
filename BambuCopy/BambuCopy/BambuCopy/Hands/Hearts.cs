using System;
using System.Collections.Generic;
using System.Text;

namespace BambuCopy
{
    class Hearts : Hand
    {
      public Hearts()
        {
            Name = "Hearts";
            Scoring = -1;
            NumOfBadCards = 8;
            Score = new List<int>() { 0, 0, 0, 0 };
        }
    }
}
