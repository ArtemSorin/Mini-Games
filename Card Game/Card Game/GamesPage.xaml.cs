using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Card_Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamesPage : ContentPage
    {
        public GamesPage()
        {
            InitializeComponent();

            card_game.Clicked += (sender, e) => Navigation.PushAsync(new CardLevelFirstPage());
            country_game.Clicked += (sender, e) => Navigation.PushAsync(new CountryLevelFirstPage());
        }
    }
}