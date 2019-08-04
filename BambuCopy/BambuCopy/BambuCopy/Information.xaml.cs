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
    public partial class Information : ContentPage
    {
        public Information()
        {
            InitializeComponent();
            EditorInfo.Text = "Editor Information:\n" +
                              "\tJoseph Burns\n" +
                              "\tJustin Archibald\n" +
                              "\tProduced: May 2109\n\n" +
                              "Future Updates:\n" +
                              "\t-Load Saved Game Feature\n" +
                              "\t-Full Game Functionality (Cards, Mutiplayer Network Gameplay, etc.)";
            BookInfo.Text = "Book Information:\n" +
                            "\t'A Quiet Game of Bambu' by Roger Gouze\n" +
                            "\tMurder Mystery";
        }
    }
}