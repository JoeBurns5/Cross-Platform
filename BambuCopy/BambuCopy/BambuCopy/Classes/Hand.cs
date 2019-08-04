using System;
using System.Collections.Generic;
using System.Text;

namespace BambuCopy
{
    abstract class Hand
    {
        public string Name { get; set; }
        public int Scoring { get; set; }
        public int NumOfBadCards { get; set; }
        public List<int> Score { get; set; }

        protected Hand(string name, int scoring, int numOfBadCards, List<int> score)
        {
            Name = name;
            Scoring = scoring;
            NumOfBadCards = numOfBadCards;
            Score = score;
        }
        
        protected Hand()
        {

        }
    }
}
