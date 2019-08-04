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
    public partial class HandScore : ContentPage
    {
        public List<string> scoring = new List<string>() { Rules.bambuScoring, Rules.heartsScoring, Rules.queensScoring, Rules.tricksScoring,
                                                           Rules.lastTrickScoring, Rules.allInOneScoring, Rules.dominoScoring };
        public List<int> handScore = new List<int> { 0, 0, 0, 0 };
        public List<EntryCell> playerScores;
        public int currentHandindex;
        public HandScore()
        {
            InitializeComponent();
            Player1.Title = GameManager.Instance.GM1.players[0];
            Player2.Title = GameManager.Instance.GM1.players[1];
            Player3.Title = GameManager.Instance.GM1.players[2];
            Player4.Title = GameManager.Instance.GM1.players[3];
            int tourindex = GameManager.Instance.GM1.tours.IndexOf(GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1]);
            currentHandindex = GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].currHandIndex;
            HandName.Text = GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].tourHands[currentHandindex];
            handScoring.Text = scoring[currentHandindex];
            playerScores = new List<EntryCell>() { P1Score, P2Score, P3Score, P4Score };
        }

        private async void GoToRules_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Rules());
        }

        private async void GoToPage_OnClicked(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (int.TryParse(playerScores[i].Text, out int score))
                {
                    handScore[i] = score;
                }
                else
                {
                    break;                    
                }
            }
            if (GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].tourScore[currentHandindex].All(s => s == 0))
            {
                GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].tourScore[currentHandindex] = handScore;
            }
            else
            {
                GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].tourScore[currentHandindex + 1] = handScore;
            }

            for (int i = 0; i < 4; i++)
            {
                GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].tourScore[8][i] += handScore[i];
            }

            GameManager.Instance.addHandTrackerToFile(GameManager.Instance.GM1.handOrder);
            GameManager.Instance.addGameScoreToFile(GameManager.Instance.GM1.tours);

            await Navigation.PushAsync(new TourScoreSheet());
        }
    }
}