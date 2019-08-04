using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BambuCopy.Classes;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BambuCopy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerEntry : ContentPage
    {
        public PlayerEntry()
        {
            InitializeComponent();
        }
        private async void GoToConductorDraw_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConductorDraw());
        }

        private void EntryPlayer1_Unfocused(object sender, FocusEventArgs e)

        {
            var p1Name = (Entry)sender;
            GameManager.Instance.GM1.players[0] = p1Name.Text;
        }

        private void EntryPlayer2_Unfocused(object sender, FocusEventArgs e)
        {
            var p2Name = (Entry)sender;
            GameManager.Instance.GM1.players[1] = p2Name.Text;
        }

        private void EntryPlayer3_Unfocused(object sender, FocusEventArgs e)
        {
            var p3Name = (Entry)sender;
            GameManager.Instance.GM1.players[2] = p3Name.Text;
        }

        private void EntryPlayer4_Unfocused(object sender, FocusEventArgs e)
        {
            var p4Name = (Entry)sender;
            GameManager.Instance.GM1.players[3] = p4Name.Text;
        }
    }
}