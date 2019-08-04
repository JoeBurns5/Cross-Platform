using System;
using System.Collections.Generic;
using System.Text;

namespace BambuCopy
{
    class Game
    {
        public List<string> players;
        public List<List<List<int>>> scores;
        public List<Tour> tours;
        public List<List<string>> handOrder;
        public int conductorCount;

        public Game()
        {
            conductorCount = 0;
            tours = new List<Tour>();
            players = new List<string>() { "", "", "", "" };
            scores = new List<List<List<int>>>();
            List<int> subT = new List<int>() { 0, 0, 0, 0 };
            handOrder = new List<List<string>>() { new List<string>() { "0", "0", "0", "0" },
                                                   new List<string>() { "0", "0", "0", "0" },
                                                   new List<string>() { "0", "0", "0", "0" },
                                                   new List<string>() { "0", "0", "0", "0" },
                                                   new List<string>() { "0", "0", "0", "0" },
                                                   new List<string>() { "0", "0", "0", "0" },
                                                   new List<string>() { "0", "0", "0", "0" },
                                                   new List<string>() { "0", "0", "0", "0" }};
        }
    }
}
