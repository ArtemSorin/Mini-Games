using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Card_Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page : ContentPage
    {
        public Page()
        {
            InitializeComponent();
        }
        async public void function1(object sender, EventArgs e)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("card.mp3");
            player.Play();
            await btn2.RotateYTo(90, 300);
            await btn1.RotateYTo(0, 300);
        }
        async public void function2(object sender, EventArgs e)
        {
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("card.mp3");
            player.Play();
            await btn1.RotateYTo(90, 300);
            await btn2.RotateYTo(0, 300);
        }
    }
}