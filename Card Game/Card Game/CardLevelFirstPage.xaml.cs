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

            Sorcepanel.Text = $"Рекорд: {sorce} / 20";

            ImageButton[] mas_buttons_card = new ImageButton[]
            {
                btn_back_1, btn_front_1, btn_back_2, btn_front_2, btn_back_3, btn_front_3, btn_back_4, btn_front_4
            };

            change_level.Clicked += (sender, e) => { Navigation.PushAsync(new CardLevelSecondPage()); };
            show_cards.Clicked += (sender, e) => { function_show_cards(mas_buttons_card); };

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
                if (count_correct[0] && count_correct[3]) { function_correct(btn_front_1, btn_front_4, count_correct, 0, 3); sorce += 10; }

                else if (count_correct[1] && count_correct[2]) { function_correct(btn_front_2, btn_front_3, count_correct, 1, 2); sorce += 10; }

                else
                {
                    await btn_front.RotateYTo(90, 150);
                    await btn_back.RotateYTo(0, 150);

                    count_correct[number] = false;
                    count_nonselected[number] = true;

                    sorce -= 5;
                }
            }

            Sorcepanel.Text = $"Рекорд: {sorce} / 20";

            if (sorce == 20)
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

            Sorcepanel.Text = $"Рекорд: {sorce} / 20";
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
            for (int i = 0; i < mas_buttons_card.Length; i+=2)
            {
                await mas_buttons_card[i].RotateYTo(90, 150);
                await mas_buttons_card[i + 1].RotateYTo(0, 150);
            }

            await Task.Delay(1000);

            for (int i = 1; i < mas_buttons_card.Length; i+=2)
            {
                await mas_buttons_card[i].RotateYTo(90, 150);
                await mas_buttons_card[i - 1].RotateYTo(0, 150);
            }

            show_cards.IsEnabled = false;
        }
    }
}