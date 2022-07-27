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
    public partial class CardLevelThirdPage : ContentPage
    {
        int sorce = 0;
        const int cards_count = 16;
        struct cards
        {
            public string image_front;
            public int card_number;
        }
        public CardLevelThirdPage()
        {
            InitializeComponent();

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("card.mp3");

            RadialGradientBrush radialGradientBrush = new RadialGradientBrush();
            radialGradientBrush.Radius = 1.5;
            radialGradientBrush.GradientStops = new GradientStopCollection()
            {
                new GradientStop(){ Color = Color.FromHex("#6231CC"), Offset = 0 },
                new GradientStop(){ Color = Color.FromHex("#7A4AE0"), Offset = 1 }
            };

            change_level.Background = radialGradientBrush;
            show_cards.Background = radialGradientBrush;

            bool[] count_correct = new bool[cards_count];
            bool[] count_nonselected = new bool[cards_count];

            for (int i = 0; i < count_correct.Length; i++) { count_correct[i] = false; }
            for (int i = 0; i < count_nonselected.Length; i++) { count_nonselected[i] = true; }

            Sorcepanel.Text = $"Рекорд: {sorce} / {count_correct.Length * 10 / 2}";

            ImageButton[] mas_buttons_card = new ImageButton[]
            {
                btn_front_1, btn_front_2, btn_front_3, btn_front_4, btn_front_5, btn_front_6, btn_front_7, btn_front_8,
                btn_front_9, btn_front_10, btn_front_11, btn_front_12, btn_front_13, btn_front_14, btn_front_15, btn_front_16,
                btn_back_1, btn_back_2, btn_back_3, btn_back_4, btn_back_5, btn_back_6, btn_back_7, btn_back_8, btn_back_9,
                btn_back_10, btn_back_11, btn_back_12, btn_back_13, btn_back_14, btn_back_15, btn_back_16
            };

            cards[] mas = new cards[cards_count];
            int[] mas_numbers = new int[cards_count];

            mas[0].image_front = "card_crown_three"; mas[0].card_number = 0;
            mas[1].image_front = "card_crown_three"; mas[1].card_number = 0;
            mas[2].image_front = "card_feather_two.png"; mas[2].card_number = 1;
            mas[3].image_front = "card_feather_two.png"; mas[3].card_number = 1;
            mas[4].image_front = "card_pen.png"; mas[4].card_number = 2;
            mas[5].image_front = "card_pen.png"; mas[5].card_number = 2;
            mas[6].image_front = "card_pie.png"; mas[6].card_number = 3;
            mas[7].image_front = "card_pie.png"; mas[7].card_number = 3;
            mas[8].image_front = "card_santa_hat.png"; mas[8].card_number = 4;
            mas[9].image_front = "card_santa_hat.png"; mas[9].card_number = 4;
            mas[10].image_front = "card_santa_hat_two.png"; mas[10].card_number = 5;
            mas[11].image_front = "card_santa_hat_two.png"; mas[11].card_number = 5;
            mas[12].image_front = "card_champagne.png"; mas[12].card_number = 6;
            mas[13].image_front = "card_champagne.png"; mas[13].card_number = 6;
            mas[14].image_front = "card_flashlight.png"; mas[14].card_number = 7;
            mas[15].image_front = "card_flashlight.png"; mas[15].card_number = 7;

            var random = new Random();
            var numbers = Enumerable.Range(0, cards_count).OrderBy(n => random.Next()).ToArray();

            for (int i = 0; i < mas_buttons_card.Length / 2; i++)
            {
                mas_buttons_card[i].Source = mas[numbers[i]].image_front;
                mas_numbers[i] = mas[numbers[i]].card_number;
            }

            var List = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < mas_numbers.Length; i++)
            {
                for (int j = i + 1; j < mas_numbers.Length; j++)
                {
                    if (mas_numbers[i] == mas_numbers[j])
                    {
                        List.Add(new KeyValuePair<int, int>(i, j));
                    }
                }
            }

            change_level.Clicked += (sender, e) => { Navigation.PushAsync(new CardLevelFourthPage()); };
            show_cards.Clicked += (sender, e) => { function_show_cards(mas_buttons_card); };

            btn_back_1.Clicked += (sender, e) => { player.Play(); function_back_to_front(0, count_nonselected, count_correct, btn_back_1, btn_front_1, mas_buttons_card, List); };
            btn_back_2.Clicked += (sender, e) => { player.Play(); function_back_to_front(1, count_nonselected, count_correct, btn_back_2, btn_front_2, mas_buttons_card, List); };
            btn_back_3.Clicked += (sender, e) => { player.Play(); function_back_to_front(2, count_nonselected, count_correct, btn_back_3, btn_front_3, mas_buttons_card, List); };
            btn_back_4.Clicked += (sender, e) => { player.Play(); function_back_to_front(3, count_nonselected, count_correct, btn_back_4, btn_front_4, mas_buttons_card, List); };
            btn_back_5.Clicked += (sender, e) => { player.Play(); function_back_to_front(4, count_nonselected, count_correct, btn_back_5, btn_front_5, mas_buttons_card, List); };
            btn_back_6.Clicked += (sender, e) => { player.Play(); function_back_to_front(5, count_nonselected, count_correct, btn_back_6, btn_front_6, mas_buttons_card, List); };
            btn_back_7.Clicked += (sender, e) => { player.Play(); function_back_to_front(6, count_nonselected, count_correct, btn_back_7, btn_front_7, mas_buttons_card, List); };
            btn_back_8.Clicked += (sender, e) => { player.Play(); function_back_to_front(7, count_nonselected, count_correct, btn_back_8, btn_front_8, mas_buttons_card, List); };
            btn_back_9.Clicked += (sender, e) => { player.Play(); function_back_to_front(8, count_nonselected, count_correct, btn_back_9, btn_front_9, mas_buttons_card, List); };
            btn_back_10.Clicked += (sender, e) => { player.Play(); function_back_to_front(9, count_nonselected, count_correct, btn_back_10, btn_front_10, mas_buttons_card, List); };
            btn_back_11.Clicked += (sender, e) => { player.Play(); function_back_to_front(10, count_nonselected, count_correct, btn_back_11, btn_front_11, mas_buttons_card, List); };
            btn_back_12.Clicked += (sender, e) => { player.Play(); function_back_to_front(11, count_nonselected, count_correct, btn_back_12, btn_front_12, mas_buttons_card, List); };
            btn_back_13.Clicked += (sender, e) => { player.Play(); function_back_to_front(12, count_nonselected, count_correct, btn_back_13, btn_front_13, mas_buttons_card, List); };
            btn_back_14.Clicked += (sender, e) => { player.Play(); function_back_to_front(13, count_nonselected, count_correct, btn_back_14, btn_front_14, mas_buttons_card, List); };
            btn_back_15.Clicked += (sender, e) => { player.Play(); function_back_to_front(14, count_nonselected, count_correct, btn_back_15, btn_front_15, mas_buttons_card, List); };
            btn_back_16.Clicked += (sender, e) => { player.Play(); function_back_to_front(15, count_nonselected, count_correct, btn_back_16, btn_front_16, mas_buttons_card, List); };

            for (int i = mas_buttons_card.Length / 2; i < mas_buttons_card.Length; i++)
            {
                mas_buttons_card[i].IsEnabled = false;
            }

            for (int i = 0; i < mas_buttons_card.Length; i++)
            {
                mas_buttons_card[i].BackgroundColor = Color.White;
            }
        }
        private async void function_back_to_front(int number, bool[] count_nonselected, bool[] count_correct, ImageButton btn_back, ImageButton btn_front, ImageButton[] mas_buttons_card, List<KeyValuePair<int, int>> mas)
        {
            await btn_back.RotateYTo(90, 150);
            await btn_front.RotateYTo(0, 150);

            count_correct[number] = true;
            count_nonselected[number] = false;

            int count = 0;

            for (int i = 0; i < count_correct.Length; i++) { if (count_correct[i]) { count++; } }

            if (count > 1)
            {
                bool flag_find_correct = false;

                for (int i = 0; i < count_correct.Length / 2; i++)
                {
                    if (count_correct[mas[i].Key] && count_correct[mas[i].Value])
                    { 
                        function_correct(mas_buttons_card[mas[i].Key], mas_buttons_card[mas[i].Value], count_correct, mas[i].Key, mas[i].Value);
                        sorce += 10;
                        flag_find_correct = true;
                    }
                }

                if (!flag_find_correct)
                {
                    function_non_correct(number, btn_front, btn_back, count_correct, count_nonselected);
                    sorce -= 5;
                }
            }

            Sorcepanel.Text = $"Рекорд: {sorce} / {count_correct.Length * 10 / 2}";

            if (function_is_all_open(count_nonselected) && sorce >= (count_correct.Length * 10 / 2) * 0.75)
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

            await Task.Delay(3000);

            for (int i = 0; i < mas_buttons_card.Length / 2; i++)
            {
                await mas_buttons_card[i].RotateYTo(90, 150);
                await mas_buttons_card[i + mas_buttons_card.Length / 2].RotateYTo(0, 150);
            }

            show_cards.IsEnabled = false;

            for (int i = mas_buttons_card.Length / 2; i < mas_buttons_card.Length; i++)
            {
                mas_buttons_card[i].IsEnabled = true;
            }
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
        private bool function_is_all_open(bool[] count_nonselected)
        {
            for (int i = 0; i < count_nonselected.Length; i++)
            {
                if (count_nonselected[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}