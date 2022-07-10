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
    public partial class CardLevelFourthPage : ContentPage
    {
        int sorce = 0;
        public CardLevelFourthPage()
        {
            InitializeComponent();

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("card.mp3");

            bool[] count_correct = new bool[20];
            bool[] count_nonselected = new bool[20];
            for (int i = 0; i < count_correct.Length; i++) { count_correct[i] = false; }
            for (int i = 0; i < count_nonselected.Length; i++) { count_nonselected[i] = true; }

            Sorcepanel.Text = $"Рекорд: {sorce}  / 100";

            ImageButton[] mas_buttons_card = new ImageButton[]
            {
                btn_back_1, btn_front_1, btn_back_2, btn_front_2, btn_back_3, btn_front_3, btn_back_4, btn_front_4,
                btn_back_5, btn_front_5, btn_back_6, btn_front_6, btn_back_7, btn_front_7, btn_back_8, btn_front_8,
                btn_back_9, btn_front_9, btn_back_10, btn_front_10, btn_back_11, btn_front_11, btn_back_12, btn_front_12,
                btn_back_13, btn_front_13, btn_back_14, btn_front_14, btn_back_15, btn_front_15, btn_back_16, btn_front_16,
                btn_back_17, btn_front_17, btn_back_18, btn_front_18, btn_back_19, btn_front_19, btn_back_20, btn_front_20,
            };

            change_level.Clicked += (sender, e) => { Navigation.PushAsync(new CardLevelFifthPage()); };
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
            btn_back_10.Clicked += (sender, e) => { player.Play(); function_back_to_front(9, count_nonselected, count_correct, btn_back_10, btn_front_10); };
            btn_back_11.Clicked += (sender, e) => { player.Play(); function_back_to_front(10, count_nonselected, count_correct, btn_back_11, btn_front_11); };
            btn_back_12.Clicked += (sender, e) => { player.Play(); function_back_to_front(11, count_nonselected, count_correct, btn_back_12, btn_front_12); };
            btn_back_13.Clicked += (sender, e) => { player.Play(); function_back_to_front(12, count_nonselected, count_correct, btn_back_13, btn_front_13); };
            btn_back_14.Clicked += (sender, e) => { player.Play(); function_back_to_front(13, count_nonselected, count_correct, btn_back_14, btn_front_14); };
            btn_back_15.Clicked += (sender, e) => { player.Play(); function_back_to_front(14, count_nonselected, count_correct, btn_back_15, btn_front_15); };
            btn_back_16.Clicked += (sender, e) => { player.Play(); function_back_to_front(15, count_nonselected, count_correct, btn_back_16, btn_front_16); };
            btn_back_17.Clicked += (sender, e) => { player.Play(); function_back_to_front(16, count_nonselected, count_correct, btn_back_17, btn_front_17); };
            btn_back_18.Clicked += (sender, e) => { player.Play(); function_back_to_front(17, count_nonselected, count_correct, btn_back_18, btn_front_18); };
            btn_back_19.Clicked += (sender, e) => { player.Play(); function_back_to_front(18, count_nonselected, count_correct, btn_back_19, btn_front_19); };
            btn_back_20.Clicked += (sender, e) => { player.Play(); function_back_to_front(19, count_nonselected, count_correct, btn_back_20, btn_front_20); };
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
                if (count_correct[0] && count_correct[10]) { function_correct(btn_front_1, btn_front_11, count_correct, 0, 10); sorce += 10; }

                else if (count_correct[1] && count_correct[12]) { function_correct(btn_front_2, btn_front_13, count_correct, 1, 12); sorce += 10; }

                else if (count_correct[2] && count_correct[9]) { function_correct(btn_front_3, btn_front_10, count_correct, 2, 9); sorce += 10; }

                else if (count_correct[3] && count_correct[11]) { function_correct(btn_front_4, btn_front_12, count_correct, 3, 11); sorce += 10; }

                else if (count_correct[4] && count_correct[19]) { function_correct(btn_front_5, btn_front_20, count_correct, 4, 19); sorce += 10; }

                else if (count_correct[5] && count_correct[13]) { function_correct(btn_front_6, btn_front_14, count_correct, 5, 13); sorce += 10; }

                else if (count_correct[6] && count_correct[16]) { function_correct(btn_front_7, btn_front_17, count_correct, 6, 16); sorce += 10; }

                else if (count_correct[7] && count_correct[14]) { function_correct(btn_front_8, btn_front_15, count_correct, 7, 14); sorce += 10; }

                else if (count_correct[8] && count_correct[15]) { function_correct(btn_front_9, btn_front_16, count_correct, 8, 15); sorce += 10; }

                else if (count_correct[17] && count_correct[18]) { function_correct(btn_front_18, btn_front_19, count_correct, 17, 18); sorce += 10; }

                else
                {
                    await btn_front.RotateYTo(90, 150);
                    await btn_back.RotateYTo(0, 150);

                    count_correct[number] = false;
                    count_nonselected[number] = true;

                    sorce -= 5;
                }
            }

            Sorcepanel.Text = $"Рекорд: {sorce} / 100";

            if (sorce == 80)
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

            Sorcepanel.Text = $"Рекорд: {sorce} / 100";
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