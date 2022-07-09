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
    public partial class CardLevelSecondPage : ContentPage
    {
        int sorce = 0;
        public CardLevelSecondPage()
        {
            InitializeComponent();

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("card.mp3");

            bool[] count_correct = new bool[9];
            bool[] count_nonselected = new bool[9];
            for (int i = 0; i < count_correct.Length; i++) { count_correct[i] = false; }
            for (int i = 0; i < count_nonselected.Length; i++) { count_nonselected[i] = true; }

            Sorcepanel.Text = $"Рекорд: {sorce} / 40";

            ImageButton[] mas_buttons_card = new ImageButton[]
            {
                btn_back_1, btn_front_1, btn_back_2, btn_front_2, btn_back_3, btn_front_3, btn_back_4, btn_front_4,
                btn_back_5, btn_front_5, btn_back_6, btn_front_6, btn_back_7, btn_front_7, btn_back_8, btn_front_8,
                btn_back_9, btn_front_9
            };

            change_level.Clicked += (sender, e) => { Navigation.PushAsync(new CardLevelThirdPage()); };
            show_cards.Clicked += (sender, e) => { function_show_cards(mas_buttons_card); };

            btn_back_1.Clicked += (sender, e) => { player.Play(); function_back_to_front(0, count_nonselected, count_correct, btn_back_1, btn_front_1); };
            btn_back_2.Clicked += (sender, e) => { player.Play(); function_back_to_front(1, count_nonselected, count_correct, btn_back_2, btn_front_2); };
            btn_back_3.Clicked += (sender, e) => { player.Play(); function_back_to_front(2, count_nonselected, count_correct, btn_back_3, btn_front_3); };
            btn_back_4.Clicked += (sender, e) => { player.Play(); function_back_to_front(3, count_nonselected, count_correct, btn_back_4, btn_front_4); };
            btn_back_5.Clicked += (sender, e) => { player.Play(); function_back_to_front(4, count_nonselected, count_correct, btn_back_5, btn_front_5); };
            btn_back_6.Clicked += (sender, e) => { player.Play(); function_back_to_front(5, count_nonselected, count_correct, btn_back_6, btn_front_6); };
            btn_back_7.Clicked += (sender, e) => { player.Play(); function_back_to_front(6, count_nonselected, count_correct, btn_back_7, btn_front_7); };
            btn_back_8.Clicked += (sender, e) => { player.Play(); function_back_to_front(7, count_nonselected, count_correct, btn_back_8, btn_front_8); };
            btn_back_9.Clicked += (sender, e) => { player.Play(); function_back_to_front(8, count_nonselected, count_correct, btn_back_9, btn_front_9); };

        }
        private async void function_back_to_front(int number, bool[] count_nonselected, bool[] count_correct, ImageButton btn_back, ImageButton btn_front)
        {
            await btn_back.RotateYTo(90, 150);
            await btn_front.RotateYTo(0, 150);
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
                if (count_correct[0] && count_correct[7]) { function_correct(btn_front_1, btn_front_8, count_correct, 0, 7); sorce += 10; }

                else if (count_correct[1] && count_correct[8]) { function_correct(btn_front_2, btn_front_9, count_correct, 1, 8); sorce += 10; }

                else if (count_correct[2] && count_correct[3]) { function_correct(btn_front_3, btn_front_4, count_correct, 2, 3); sorce += 10; }

                else if (count_correct[4] && count_correct[5]) { function_correct(btn_front_5, btn_front_6, count_correct, 4, 5); sorce += 10; }

                else
                {
                    await btn_front.RotateYTo(90, 150);
                    await btn_back.RotateYTo(0, 150);

                    count_correct[number] = false;
                    count_nonselected[number] = true;

                    sorce -= 5;
                }
            }

            Sorcepanel.Text = $"Рекорд: {sorce} / 40";

            if (sorce == 40)
            {
                await DisplayAlert("", "Уровень пройден!", "ок");
                change_level.IsEnabled = true;
            }

        }
        private async void function_front_to_back(int number, bool[] count_nonselected, bool[] count_correct, ImageButton btn_front, ImageButton btn_back)
        {
            await btn_front.RotateYTo(90, 150);
            await btn_back.RotateYTo(0, 150);
            count_correct[number] = false;
            count_nonselected[number] = true;

            Sorcepanel.Text = $"Рекорд: {sorce} / 40";
        }
        private void function_correct(ImageButton btn1, ImageButton btn2, bool[] count_correct, int index1, int index2)
        {
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;

            count_correct[index1] = false;
            count_correct[index2] = false;
        }
        private async void function_show_cards(ImageButton[] mas_buttons_card)
        {
            for (int i = 0; i < mas_buttons_card.Length; i += 2)
            {
                await mas_buttons_card[i].RotateYTo(90, 150);
                await mas_buttons_card[i + 1].RotateYTo(0, 150);
            }

            await Task.Delay(1000);

            for (int i = 1; i < mas_buttons_card.Length; i += 2)
            {
                await mas_buttons_card[i].RotateYTo(90, 150);
                await mas_buttons_card[i - 1].RotateYTo(0, 150);
            }

            show_cards.IsEnabled = false;
        }
    }
}