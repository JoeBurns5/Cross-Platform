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
    public partial class TourScoreSheet : ContentPage
    {
        public List<List<Label>> TourScores;
        public List<Label> Subtotals;
        public List<Label> handNames;

        public TourScoreSheet()
        {
            InitializeComponent();
            PlayerName1.Text = GameManager.Instance.GM1.players[0];
            PlayerName2.Text = GameManager.Instance.GM1.players[1];
            PlayerName3.Text = GameManager.Instance.GM1.players[2];
            PlayerName4.Text = GameManager.Instance.GM1.players[3];
            TourScores = new List<List<Label>>() { new List<Label>() { ScoreCell1, ScoreCell2, ScoreCell3, ScoreCell4 },
                                                   new List<Label>() { ScoreCell5, ScoreCell6, ScoreCell7, ScoreCell8 },
                                                   new List<Label>() { ScoreCell9, ScoreCell10, ScoreCell11, ScoreCell12 },
                                                   new List<Label>() { ScoreCell13, ScoreCell14, ScoreCell15, ScoreCell16 },
                                                   new List<Label>() { ScoreCell17, ScoreCell18, ScoreCell19, ScoreCell20 },
                                                   new List<Label>() { ScoreCell21, ScoreCell22, ScoreCell23, ScoreCell24 },
                                                   new List<Label>() { ScoreCell25, ScoreCell26, ScoreCell27, ScoreCell28 },
                                                   new List<Label>() { ScoreCell29, ScoreCell30, ScoreCell31, ScoreCell32 }};
            Subtotals = new List<Label>() { ScoreCellSub1, ScoreCellSub2, ScoreCellSub3, ScoreCellSub4 };
            handNames = new List<Label>() { Hand1, Hand2, Hand3, Hand4, Hand5, Hand6, Hand7, Hand8 };

            for (int i = 0; i < 8; i++)
                handNames[i].Text = GameManager.Instance.GM1.tours[GameManager.Instance.GM1.tours.Count - 1].tourHands[i];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TourScores[i][j].Text = GameManager.Instance.GM1.tours[GameManager.Instance.GM1.tours.Count - 1].tourScore[i][j].ToString();
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Subtotals[i].Text = GameManager.Instance.GM1.tours[GameManager.Instance.GM1.tours.Count - 1].tourScore[8][i].ToString();
            }
        }

        private async void GoToHandTracker_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HandTracker());
        }

        private async void GoToPage_OnClicked(object sender, EventArgs e)
        {
            if (GameManager.Instance.GM1.tours.Count != 4)
            {
                if (GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].handsToComplete.Count != 0)
                {
                    await Navigation.PushAsync(new HandPicker());
                }
                else
                {
                    Tour newTour = new Tour(GameManager.Instance.GM1.players[GameManager.Instance.GM1.conductorCount], GameManager.Instance.GM1.tours[GameManager.Instance.GM1.tours.Count - 1].tourScore[8]);
                    GameManager.Instance.GM1.tours.Add(newTour);
                    GameManager.Instance.GM1.conductorCount++;
                    await Navigation.PushAsync(new HandPicker());
                }
            }
            else
            {
                if (GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].handsToComplete.Count != 0)
                {
                    await Navigation.PushAsync(new HandPicker());
                }
                else
                {
                    await Navigation.PushAsync(new FinalScore());
                }
            }
        }
    }
}