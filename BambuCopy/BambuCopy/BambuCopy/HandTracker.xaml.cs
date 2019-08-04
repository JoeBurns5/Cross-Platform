using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BambuCopy.Classes;

namespace BambuCopy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HandTracker : ContentPage
    {
        public List<Label> playerTours;
        public List<List<Label>> handTrackerGrid;
        public HandTracker()
        {
            InitializeComponent();
            playerTours = new List<Label>() { p1tour, p2tour, p3tour, p4tour };
            handTrackerGrid = new List<List<Label>>() { new List<Label>() { h1t1, h1t2, h1t3, h1t4 },
                                                        new List<Label>() { h2t1, h2t2, h2t3, h2t4 },
                                                        new List<Label>() { h3t1, h3t2, h3t3, h3t4 },
                                                        new List<Label>() { h4t1, h4t2, h4t3, h4t4 },
                                                        new List<Label>() { h5t1, h5t2, h5t3, h5t4 },
                                                        new List<Label>() { h6t1, h6t2, h6t3, h6t4 },
                                                        new List<Label>() { h7t1, h7t2, h7t3, h7t4 },
                                                        new List<Label>() { h8t1, h8t2, h8t3, h8t4 }};

            for (int i = 0; i < 4; i++)
            {
                playerTours[i].Text = GameManager.Instance.GM1.players[i];
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    handTrackerGrid[i][j].Text = GameManager.Instance.GM1.handOrder[i][j];
                }
            }
        }
    }
}