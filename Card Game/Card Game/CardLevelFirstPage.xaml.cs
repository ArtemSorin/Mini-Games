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
        int score = 0;
        const int cards_count = 4;
        public struct cards
        {
            public string image_front;
            public int card_number;
            public bool correct;
            public bool nonselected;
        }
        public CardLevelFirstPage()
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

            cards[] mas = new cards[cards_count];
            int[] mas_numbers = new int[cards_count];

            Sorcepanel.Text = $"Рекорд: {score} / {mas.Length * 10 / 2}";

            ImageButton[] mas_buttons_card = new ImageButton[]
            {
                btn_front_1, btn_front_2, btn_front_3, btn_front_4, btn_back_1, btn_back_2, btn_back_3, btn_back_4
            };

            mas[0].image_front = "card_cheese.png"; mas[0].card_number = 0;
            mas[1].image_front = "card_cheese.png"; mas[1].card_number = 0;
            mas[2].image_front = "card_flashlight.png"; mas[2].card_number = 1;
            mas[3].image_front = "card_flashlight.png"; mas[3].card_number = 1;

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i].correct = false;
                mas[i].nonselected = true;
            }

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

            change_level.Clicked += (sender, e) => { Navigation.PushAsync(new CardLevelSecondPage()); };
            show_cards.Clicked += (sender, e) => { function_show_cards(mas_buttons_card); };

            btn_back_1.Clicked += (sender, e) => { player.Play(); function_back_to_front(0, mas, btn_back_1, btn_front_1, mas_buttons_card, List); };
            btn_back_2.Clicked += (sender, e) => { player.Play(); function_back_to_front(1, mas, btn_back_2, btn_front_2, mas_buttons_card, List); };
            btn_back_3.Clicked += (sender, e) => { player.Play(); function_back_to_front(2, mas, btn_back_3, btn_front_3, mas_buttons_card, List); };
            btn_back_4.Clicked += (sender, e) => { player.Play(); function_back_to_front(3, mas, btn_back_4, btn_front_4, mas_buttons_card, List); };

            for (int i = mas_buttons_card.Length / 2; i < mas_buttons_card.Length; i++)
            {
                mas_buttons_card[i].IsEnabled = false;
            }

            for (int i = 0; i < mas_buttons_card.Length; i++)
            {
                mas_buttons_card[i].BackgroundColor = Color.White;
            }
        }
        private async void function_back_to_front(int number, cards[] mas_card, ImageButton btn_back, ImageButton btn_front, ImageButton[] mas_buttons_card, List<KeyValuePair<int, int>> mas)
        {
            await btn_back.RotateYTo(90, 150);
            await btn_front.RotateYTo(0, 150);

            mas_card[number].correct = true;
            mas_card[number].nonselected = false;

            int count = 0;

            for (int i = 0; i < mas_card.Length; i++) 
            { 
                if (mas_card[i].correct) 
                { 
                    count++; 
                }
            }

            if (count > 1)
            {
                bool flag_find_correct = false;

                for (int i = 0; i < mas_card.Length / 2; i++)
                {
                    if (mas_card[mas[i].Key].correct && mas_card[mas[i].Value].correct)
                    {
                        function_correct(mas_buttons_card[mas[i].Key], mas_buttons_card[mas[i].Value], mas_card, mas[i].Key, mas[i].Value);
                        score += 10;
                        flag_find_correct = true;
                    }
                }

                if (!flag_find_correct)
                {
                    function_non_correct(number, btn_front, btn_back, mas_card);
                    score -= 5;
                }
            }

            Sorcepanel.Text = $"Рекорд: {score} / {mas_card.Length * 10 / 2}";

            if (function_is_all_open(mas_card) && score >= (mas_card.Length * 10 / 2) * 0.75)
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

            for (int i = mas_buttons_card.Length / 2; i < mas_buttons_card.Length; i++)
            {
                mas_buttons_card[i].IsEnabled = true;
            }
        }
        private void function_correct(ImageButton btn1, ImageButton btn2, cards[] mas_card, int index1, int index2)
        {
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;

            mas_card[index1].correct = false;
            mas_card[index2].correct = false;
        }
        private async void function_non_correct(int number, ImageButton btn1, ImageButton btn2, cards[] mas_card)
        {
            await btn1.RotateYTo(90, 150);
            await btn2.RotateYTo(0, 150);

            mas_card[number].correct = false;
            mas_card[number].nonselected = true;
        }
        private bool function_is_all_open(cards[] mas_card)
        {
            for(int i = 0; i < mas_card.Length; i++)
            {
                if (mas_card[i].nonselected)
                {
                    return false;
                }
            }
            return true;
        }
    }
}