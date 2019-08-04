using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BambuCopy.Classes;

namespace BambuCopy
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        Game GM1;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToRules_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Rules());
        }

        private async void GoToInfo_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Information());
        }

        private async void NewGame_OnClicked(object sender, EventArgs e)
        {
            GameManager.Instance.newGame();
            await Navigation.PushAsync(new PlayerEntry());
        }

        private async void ContinueGame_OnClicked(object sender, EventArgs e)
        {
            GameManager.Instance.continueGame();
            await Navigation.PushAsync(new HandPicker());
        }
    }
}
