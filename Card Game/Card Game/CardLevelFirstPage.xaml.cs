﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Card_Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardLevelFirstPage : ContentPage
    {
        int sorce = 0;
        public CardLevelFirstPage()
        {
            InitializeComponent();

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("card.mp3");

            bool[] count_correct = new bool[4];
            bool[] count_nonselected = new bool[4];
            for (int i = 0; i < count_correct.Length; i++) { count_correct[i] = false; }
            for (int i = 0; i < count_nonselected.Length; i++) { count_nonselected[i] = true; }

            Sorcepanel.Text = $"Рекорд: {sorce}";

            change_level.Clicked += (sender, e) => { Navigation.PushAsync(new CardLevelSecondPage()); };

            btn_back_1.Clicked += (sender, e) => { player.Play(); function_back_to_front(0, count_nonselected, count_correct, btn_back_1, btn_front_1); };
            btn_front_1.Clicked += (sender, e) => { player.Play(); function_front_to_back(0, count_nonselected, count_correct, btn_front_1, btn_back_1); };
            btn_back_2.Clicked += (sender, e) => { player.Play(); function_back_to_front(1, count_nonselected, count_correct, btn_back_2, btn_front_2); };
            btn_front_2.Clicked += (sender, e) => { player.Play(); function_front_to_back(1, count_nonselected, count_correct, btn_front_2, btn_back_2); };
            btn_back_3.Clicked += (sender, e) => { player.Play(); function_back_to_front(2, count_nonselected, count_correct, btn_back_3, btn_front_3); };
            btn_front_3.Clicked += (sender, e) => { player.Play(); function_front_to_back(2, count_nonselected, count_correct, btn_front_3, btn_back_3); };
            btn_back_4.Clicked += (sender, e) => { player.Play(); function_back_to_front(3, count_nonselected, count_correct, btn_back_4, btn_front_4); };
            btn_front_4.Clicked += (sender, e) => { player.Play(); function_front_to_back(3, count_nonselected, count_correct, btn_front_4, btn_back_4); };
        }
        private async void function_back_to_front(int number, bool[] count_nonselected, bool[] count_correct, ImageButton btn_back, ImageButton btn_front)
        {
            await btn_back.RotateYTo(90, 300);
            await btn_front.RotateYTo(0, 300);
            count_correct[number] = true;
            count_nonselected[number] = false;

            int count = 0;

            for (int i = 0; i < count_correct.Length; i++)
            {
                if (count_correct[i])
                {
                    count++;
                }
            }

            if (count > 1)
            {
                if (count_correct[0] && count_correct[3])
                {
                    btn_front_1.IsEnabled = false;
                    btn_front_4.IsEnabled = false;

                    count_correct[0] = false;
                    count_correct[3] = false;
                    sorce += 10;
                }
                else if (count_correct[1] && count_correct[2])
                {
                    btn_front_2.IsEnabled = false;
                    btn_front_3.IsEnabled = false;

                    count_correct[1] = false;
                    count_correct[2] = false;
                    sorce += 10;
                }
                else
                {
                    await btn_front.RotateYTo(90, 300);
                    await btn_back.RotateYTo(0, 300);

                    sorce -= 5;
                }
            }

            if (sorce == 20)
            {
                change_level.IsEnabled = true;
            }

            Sorcepanel.Text = $"Рекорд: {sorce}";
        }
        private async void function_front_to_back(int number, bool[] count_nonselected, bool[] count_correct, ImageButton btn_front, ImageButton btn_back)
        {
            await btn_front.RotateYTo(90, 300);
            await btn_back.RotateYTo(0, 300);
            count_correct[number] = false;
            count_nonselected[number] = true;

            Sorcepanel.Text = $"Рекорд: {sorce}";
        }
    }
}