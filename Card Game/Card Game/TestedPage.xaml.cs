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
    public partial class TestedPage : ContentPage
    {
        int sorce = 0;
        struct cards
        {
            public string image_front;
            public int card_number;
        }
        public TestedPage()
        {
            InitializeComponent();

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("card.mp3");

            bool[] count_correct = new bool[4];
            bool[] count_nonselected = new bool[4];

            for (int i = 0; i < count_correct.Length; i++) { count_correct[i] = false; count_nonselected[i] = true; }

            ImageButton[] mas_buttons_card = new ImageButton[]
            {
                btn_front_1, btn_front_2, btn_front_3, btn_front_4, btn_back_1, btn_back_2, btn_back_3, btn_back_4
            };

            cards[] mas = new cards[4];
            int[] mas_numbers = new int[4];

            mas[0].image_front = "jack_of_clubs.png"; mas[0].card_number = 0;
            mas[1].image_front = "jack_of_clubs.png"; mas[1].card_number = 0;
            mas[2].image_front = "ace_of_diamonds.png"; mas[2].card_number = 1;
            mas[3].image_front = "ace_of_diamonds.png"; mas[3].card_number = 1;

            var random = new Random();
            var numbers = Enumerable.Range(0, 4).OrderBy(n => random.Next()).ToArray();

            for (int i = 0; i < mas_buttons_card.Length / 2; i++)
            {
                mas_buttons_card[i].Source = mas[numbers[i]].image_front;
                mas_numbers[i] = mas[numbers[i]].card_number;
            }

            var List = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < mas_buttons_card.Length / 2; i++)
            {
                for (int j = i + 1; j < mas_buttons_card.Length / 2; j++)
                {
                    if (mas_numbers[i] == mas_numbers[j])
                    {
                        List.Add(new KeyValuePair<int, int>(i, j));
                    }
                }
            }

            Sorcepanel.Text = $"Рекорд: {sorce}/ 20";

            show_cards.Clicked += (sender, e) => { function_show_cards(mas_buttons_card); };

            btn_back_1.Clicked += (sender, e) => { player.Play(); function_back_to_front(0, count_nonselected, count_correct, btn_back_1, btn_front_1, mas_buttons_card, List); };
            btn_back_2.Clicked += (sender, e) => { player.Play(); function_back_to_front(1, count_nonselected, count_correct, btn_back_2, btn_front_2, mas_buttons_card, List); };
            btn_back_3.Clicked += (sender, e) => { player.Play(); function_back_to_front(2, count_nonselected, count_correct, btn_back_3, btn_front_3, mas_buttons_card, List); };
            btn_back_4.Clicked += (sender, e) => { player.Play(); function_back_to_front(3, count_nonselected, count_correct, btn_back_4, btn_front_4, mas_buttons_card, List); };
        }
        private async void function_back_to_front(int number, bool[] count_nonselected, bool[] count_correct, ImageButton btn_back, ImageButton btn_front, ImageButton[] mas_buttons_card, List<KeyValuePair<int, int>> mas)
        {
            await btn_back.RotateYTo(90, 150);
            await btn_front.RotateYTo(0, 150);

            count_correct[number] = true;
            count_nonselected[number] = false;

            int count = 0;

            for (int i = 0; i < count_correct.Length; i++) { if (count_correct[i]) { count++; } }

            if(count > 1)
            {
                if (count_correct[mas[0].Key] && count_correct[mas[0].Value]) { function_correct(btn_front_1, btn_front_4, count_correct, mas[0].Key, mas[0].Value); sorce += 10; }

                else if (count_correct[mas[1].Key] && count_correct[mas[1].Value]) { function_correct(btn_front_2, btn_front_3, count_correct, mas[1].Key, mas[1].Key); sorce += 10; }

                else { function_non_correct(number, btn_front, btn_back, count_correct, count_nonselected); sorce -= 5; }
            }

            Sorcepanel.Text = $"Рекорд: {sorce} / 20";

            if (sorce == 20)
            {
                await DisplayAlert("", "Уровень пройден!", "ок");
                change_level.IsEnabled = true;
            }
        }
        private async void function_show_cards(ImageButton[] mas_buttons_card)
        {
            for (int i = 0; i < mas_buttons_card.Length / 2; i++)
            {
                await mas_buttons_card[i + mas_buttons_card.Length / 2].RotateYTo(90, 150);
                await mas_buttons_card[i].RotateYTo(0, 150);
            }

            await Task.Delay(1000);

            for (int i = 0; i < mas_buttons_card.Length / 2; i++)
            {
                await mas_buttons_card[i].RotateYTo(90, 150);
                await mas_buttons_card[i + mas_buttons_card.Length / 2].RotateYTo(0, 150);
            }

            show_cards.IsEnabled = false;
        }
        private void function_correct(ImageButton btn1, ImageButton btn2, bool[] count_correct, int index1, int index2)
        {
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;

            count_correct[index1] = false;
            count_correct[index2] = false;
        }
        private async void function_non_correct(int number, ImageButton btn1, ImageButton btn2, bool[] count_correct, bool[] count_nonselected)
        {
            await btn1.RotateYTo(90, 150);
            await btn2.RotateYTo(0, 150);

            count_correct[number] = false;
            count_nonselected[number] = true;
        }
    }
}