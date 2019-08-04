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
    public partial class ConductorDraw : ContentPage
    {
        public static List<string> playerNames = GameManager.Instance.GM1.players;

        public ConductorDraw()
        {
            InitializeComponent();
            PlayerPicker.ItemsSource = playerNames;
        }

        private void UpdateConductorOrder(object sender, EventArgs e)
        {
            string temp = "";
            temp = PlayerPicker.SelectedItem.ToString();
            int tourConduct = TourPicker.SelectedIndex;

            while (playerNames[tourConduct] != temp)
            {
                string t1 = playerNames[0];
                playerNames.RemoveAt(0);
                playerNames.Add(t1);
            }
        }

        private async void GoToHandScore_OnClicked(object sender, EventArgs e)
        {
            try
            {
                GameManager.Instance.GM1.players = playerNames;
                Tour tour1 = new Tour(playerNames[GameManager.Instance.GM1.conductorCount], new List<int>() { 0, 0, 0, 0 });
                GameManager.Instance.GM1.tours.Add(tour1);
                GameManager.Instance.addPlayersToFile(playerNames);
                GameManager.Instance.GM1.conductorCount++;
                await Navigation.PushAsync(new HandPicker());
            }
            catch
            {
                return;
            }
        }
        private async void GoToPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HandScore());
        }
    }
}