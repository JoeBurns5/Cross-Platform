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
    public partial class FinalScore : ContentPage
    {
        public FinalScore()
        {
            List<int> Totals = SumTours();
            InitializeComponent();
            Player1.Text = GameManager.Instance.GM1.players[0];
            Player2.Text = GameManager.Instance.GM1.players[1];
            Player3.Text = GameManager.Instance.GM1.players[2];
            Player4.Text = GameManager.Instance.GM1.players[3];

            ScoreP1.Text = Totals[0].ToString();
            ScoreP2.Text = Totals[1].ToString();
            ScoreP3.Text = Totals[2].ToString();
            ScoreP4.Text = Totals[3].ToString();

            int winningScore = Totals.Max();
            int winningIndex = Totals.IndexOf(winningScore);

            Winner.Text = "WINNER!\n" + GameManager.Instance.GM1.players[0] + "\n"
                + winningScore.ToString();
        }

        private async void GoToMain_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        List<int> SumTours()
        {
            List<int> Total = new List<int> { 0,0,0,0};
            int tourCount = GameManager.Instance.GM1.tours.Count - 1;
            for (int i = 0; i < 4; i++)
            {
                foreach (var tour in GameManager.Instance.GM1.tours)
                {
                    Total[i] += tour.tourScore[8][i];
                }
            }
            return Total;
        }
    }
}