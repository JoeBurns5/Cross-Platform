using System;
using System.Collections.Generic;
using System.Text;

namespace BambuCopy
{
    class Tour
    {
        public List<List<int>> tourScore;
        public List<string> tourHands = new List<string>() { "Bambu", "Hearts", "Queens", "Tricks", "Last Trick", "All-in-One", "Domino", "Domino" };
        public int currHandIndex;
        public string tourConductor;
        public List<int> handTrack;
        public int handCount;
        public List<string> handsToComplete;
        public string dominoToThe;

        public Tour(string conductor, List<int> subtotal)
        {
            handCount = 1;
            tourScore = new List<List<int>>() { new List<int>(){ 0, 0, 0, 0},
                                                new List<int>(){ 0, 0, 0, 0},
                                                new List<int>(){ 0, 0, 0, 0},
                                                new List<int>(){ 0, 0, 0, 0},
                                                new List<int>(){ 0, 0, 0, 0},
                                                new List<int>(){ 0, 0, 0, 0},
                                                new List<int>(){ 0, 0, 0, 0},
                                                new List<int>(){ 0, 0, 0, 0},
                                                new List<int>(){ 0, 0, 0, 0} };
            tourConductor = conductor;
            handTrack = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 };
            currHandIndex = 0;
            handsToComplete = new List<string>() { "Bambu", "Hearts", "Queens", "Tricks", "Last Trick", "All-in-One", "Domino", "Domino" };
        }
    }
}
