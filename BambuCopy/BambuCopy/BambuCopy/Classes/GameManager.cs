using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BambuCopy.Classes
{
    class GameManager
    {
        public Game GM1;
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public string nameFilePath = Path.Combine(path, "names.csv");
        public string handFilePath = Path.Combine(path, "hands.csv");
        public string tourFilePath = Path.Combine(path, "score.csv");

        #region Singleton
        static GameManager instance;

        public static GameManager Instance
        {
            get { return instance ?? (instance = new GameManager());}
        }

        private GameManager()
        {
        }
        #endregion

        public void newGame()
        {
            GM1 = new Game();
        }

        public void continueGame()
        {
            GM1 = new Game();
            GM1.players = getPlayerNames();
            GM1.handOrder = getHandOrder();
            GM1.tours = getGameScore(GM1.players);
        }

        //list of player names
        public void addPlayersToFile(List<string> playerNames)
        {
            if (File.Exists(nameFilePath))
            {
                File.Delete(nameFilePath);
            }
            using (var file = File.CreateText(nameFilePath))
            {
                   file.WriteLine(string.Join(",", playerNames));
            }
        }

        //4 x 8 list of ints tracking the order that the hands are played in by conductor
        public void addHandTrackerToFile(List<List<string>> handOrderTable)
        {
            if (File.Exists(handFilePath))
            {
                File.Delete(handFilePath);
            }
            using (var file = File.CreateText(handFilePath))
            {
                foreach (List<string> hand in handOrderTable)
                {
                    file.WriteLine(string.Join(",", hand));
                }
            }
        }

        //Lines 1 - 9 are tour 1 scores. 4 x 9 list of ints.  rows 1-8 are scores, row 9 is subtotal.
        //Lines 10 - 19 are tour 2. same pattern
        //Lines 20 - 29 are tour 3.
        //Lines 30 - 39 are tour 4.  last line being final score
        public void addGameScoreToFile(List<Tour> tours)
        {
            if (File.Exists(tourFilePath))
            {
                File.Delete(tourFilePath);
            }
            using (var file = File.CreateText(tourFilePath))
            {
                foreach (Tour tour in tours)
                {
                    foreach (List<int> handScore in tour.tourScore)
                    {
                        file.WriteLine(string.Join(",", handScore));
                    }
                }
            }
        }
        
        //Get player names from file
        public List<string> getPlayerNames()
        {
            List<string> pNames = new List<string>();
            using (var reader = new StreamReader(@nameFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var names = line.Split(',');
                    for (int i = 0; i < 4; i++)
                    {
                        pNames.Add(names[i]);
                    }                    
                }
            }
            return pNames;
        }

        //Get hand order tracker from file
        public List<List<string>> getHandOrder()
        {
            List<List<string>> handOrder = new List<List<string>>();
            List<string> hand = new List<string>();
            using (var reader = new StreamReader(@handFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var order = line.Split(',');
                    for (int i = 0; i < 4; i++)
                    {
                        hand.Add(order[i]);
                    }
                    handOrder.Add(hand);
                }
            }
            return handOrder;
        }

        //Get game score from file
        public List<Tour> getGameScore(List<string> playerNames)
        {
            List<Tour> tours = new List<Tour>();
            Tour tour1 = new Tour(playerNames[0], new List<int>() { 0, 0, 0, 0 });
            List<int> handScore;
            List<List<int>> allScores = new List<List<int>>();
            using (var reader = new StreamReader(@tourFilePath))
            {
                while (!reader.EndOfStream)
                {
                    handScore = new List<int>();
                    var line = reader.ReadLine();
                    var value = line.Split(',');
                    for (int i = 0; i < 4; i++)
                    {
                        try
                        {
                            handScore.Add(int.Parse(value[i]));
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    allScores.Add(handScore);
                }
            }

            if (allScores.Count > 9)
            {                
                int i = 0;
                for (int j = 0; j < 9; j++)
                {
                    tour1.tourScore[i] = allScores[j];
                    i++;
                }
                tours.Add(tour1);

                if (allScores.Count == 10)
                {
                    return tours;
                }

                Tour tour2 = new Tour(playerNames[1], tour1.tourScore[8]);
                i = 0;
                for (int j = 9; j < 18; j++)
                {
                    tour2.tourScore[i] = allScores[j];
                    i++;
                }
                tours.Add(tour2);

                if (allScores.Count > 18)
                {
                    if (allScores.Count == 19)
                    {
                        return tours;
                    }
                    Tour tour3 = new Tour(playerNames[2], tour2.tourScore[8]);
                    i = 0;
                    for (int j = 18; j < 27; j++)
                    {
                        tour3.tourScore[i] = allScores[j];
                        i++;
                    }
                    tours.Add(tour3);

                    if (allScores.Count > 27)
                    {
                        if (allScores.Count == 28)
                        {
                            return tours;
                        }
                        Tour tour4 = new Tour(playerNames[3], tour3.tourScore[8]);
                        i = 0;
                        for (int j = 27; j < 37; j++)
                        {
                            tour3.tourScore[i] = allScores[j];
                            i++;
                        }
                        tours.Add(tour4);
                    }
                }
            }
            else
            {
                int i = 0;
                for (int j = 0; j < 9; j++)
                {
                    tour1.tourScore[i] = allScores[j];
                    i++;
                }
                tours.Add(tour1);
            }

            return tours;
        }
    }
}
