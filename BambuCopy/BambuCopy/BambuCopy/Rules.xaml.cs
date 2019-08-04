using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BambuCopy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Rules : ContentPage
    {
        public static string bambuScoring = "King of Hearts = -8\nTotal Score for hand = -8";
        public static string heartsScoring = "Each heart = -1\nTotal Score for hand = -8";
        public static string queensScoring = "Each Queen = -2\nTotal Score for hand = -8";
        public static string tricksScoring = "Each Trick = -1\nTotal Score for hand = -8 / +40";
        public static string lastTrickScoring = "Last Trick = -8\nTotal Score for hand = -8";
        public static string allInOneScoring = "King of Hearts = -8\nEach Heart = -1\nEach Queen = -2\n" +
                                        "Each Trick = -1\nLast Trick = -8\nTotal Score for hand = -40";
        public static string dominoScoring = "First Out = +20\nSecond = +10\n Remainder = 0";
        public Rules()
        {
            InitializeComponent();
        }
    }
}