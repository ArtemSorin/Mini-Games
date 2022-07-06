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

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("card.mp3");

            int count_correct_cards = 0;
            int score = 0;

            bool[] count_correct = new bool[4];

            for(int i = 0; i < count_correct.Length; i++) { count_correct[i] = false; }

            btn_back_1.Clicked += async (sender, e) =>
            {
                player.Play();
                await btn_back_1.RotateYTo(90, 300);
                await btn_front_1.RotateYTo(0, 300);
                count_correct[0] = true;
            };
            btn_front_1.Clicked += async (sender, e) =>
            {
                player.Play();
                await btn_front_1.RotateYTo(90, 300);
                await btn_back_1.RotateYTo(0, 300);
                count_correct[0] = false;
            };
            btn_back_2.Clicked += async (sender, e) =>
            {
                player.Play();
                await btn_back_2.RotateYTo(90, 300);
                await btn_front_2.RotateYTo(0, 300);
                count_correct[1] = true;
            };
            btn_front_2.Clicked += async (sender, e) =>
            {
                player.Play();
                await btn_front_2.RotateYTo(90, 300);
                await btn_back_2.RotateYTo(0, 300);
                count_correct[1] = false;
            };
            btn_back_3.Clicked += async (sender, e) =>
            {
                player.Play();
                await btn_back_3.RotateYTo(90, 300);
                await btn_front_3.RotateYTo(0, 300);
                count_correct[2] = true;
            };
            btn_front_3.Clicked += async (sender, e) =>
            {
                player.Play();
                await btn_front_3.RotateYTo(90, 300);
                await btn_back_3.RotateYTo(0, 300);
                count_correct[2] = false;
            };
            btn_back_4.Clicked += async (sender, e) =>
            {
                player.Play();
                await btn_back_4.RotateYTo(90, 300);
                await btn_front_4.RotateYTo(0, 300);
                count_correct[3] = true;
            };
            btn_front_4.Clicked += async (sender, e) =>
            {
                player.Play();
                await btn_front_4.RotateYTo(90, 300);
                await btn_back_4.RotateYTo(0, 300);
                count_correct[3] = false;
            };


        }
    }
}