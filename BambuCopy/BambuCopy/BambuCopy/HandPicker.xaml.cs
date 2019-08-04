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
    public partial class HandPicker : ContentPage
    {
        public List<string> hands = GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].tourHands;
        public List<string> dominoOpts = new List<string>() { "A",
                                                              "K",
                                                              "Q",
                                                              "J",
                                                              "10",
                                                              "9",
                                                              "8",
                                                              "7" };

        public HandPicker()
        {
            InitializeComponent();

            Conductor.Text = GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].tourConductor;
            SelectHand.ItemsSource = GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].handsToComplete;
            DominoToThe.ItemsSource = dominoOpts;

        }

        private void DominoSelected(object sender, EventArgs e)
        {
            string hand = SelectHand.SelectedItem.ToString();
            if (hand == "Domino")
            {
                DominoToThe.IsVisible = true;
            }
            else
                DominoToThe.IsVisible = false;
        }

        private async void GoToRules_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Rules());
        }

        private async void GoToHandTracker_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HandTracker());
        }

        private async void GoToHandScore_OnClicked(object sender, EventArgs e)
        {
            try
            {
                string hand;
                if (SelectHand.SelectedItem.ToString() == "Domino")
                {
                    hand = SelectHand.SelectedItem.ToString() + " to the " + DominoToThe.SelectedItem.ToString();
                }
                else
                    hand = SelectHand.SelectedItem.ToString();

                var confirm = await DisplayAlert("Confirm Hand", "Play " + hand + "?", "Yes", "No");
                if (confirm)
                {
                    int tourindex = GameManager.Instance.GM1.tours.IndexOf(GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1]);
                    int handindex = GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].tourHands.IndexOf(SelectHand.SelectedItem.ToString());
                    if (SelectHand.SelectedItem.ToString() == "Domino")
                    {
                        string dominoStr = (GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].handCount.ToString()) + "  (" + DominoToThe.SelectedItem.ToString() + ")";
                        if (GameManager.Instance.GM1.handOrder[handindex][tourindex] == "0")
                        {
                            GameManager.Instance.GM1.handOrder[handindex][tourindex] = dominoStr;
                        }
                        else
                        {
                            GameManager.Instance.GM1.handOrder[handindex + 1][tourindex] = dominoStr;
                        }
                    }
                    else
                    {
                        GameManager.Instance.GM1.handOrder[handindex][tourindex] = GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].handCount.ToString();
                    }
                    GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].handCount++;
                    GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].currHandIndex = handindex;
                    GameManager.Instance.GM1.tours[(GameManager.Instance.GM1.tours).Count - 1].handsToComplete.Remove(SelectHand.SelectedItem.ToString());
                    await Navigation.PushAsync(new HandScore());
                }
            }
            catch(Exception)
            {
                return;
            }
        }
    }
}