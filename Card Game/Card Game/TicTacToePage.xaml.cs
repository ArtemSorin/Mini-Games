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
    public partial class TicTacToePage : ContentPage
    {
        int score_first_player = 0;
        int score_second_player = 0;
        public TicTacToePage()
        {
            InitializeComponent();

            RadialGradientBrush radialGradientBrush = new RadialGradientBrush();
            radialGradientBrush.Radius = 1.5;
            radialGradientBrush.GradientStops = new GradientStopCollection()
            {
                new GradientStop(){ Color = Color.FromHex("#6231CC"), Offset = 0 },
                new GradientStop(){ Color = Color.FromHex("#7A4AE0"), Offset = 1 }
            };

            button_new_round.Background = radialGradientBrush;
            button_new_round.IsEnabled = false;

            ImageButton[,] mas = new ImageButton[,]
            {
                { button1, button2, button3 },
                { button4, button5, button6 },
                { button7, button8, button9 },
            };

            int count = 0;

            char[,] masct = new char[,]
            {
                { '0', '0', '0'},
                { '0', '0', '0'},
                { '0', '0', '0'},
            };

            button1.Clicked += (sender, e) => { function_on_click(0, 0, ref count, mas, masct); button1.IsEnabled = false; };
            button2.Clicked += (sender, e) => { function_on_click(0, 1, ref count, mas, masct); button2.IsEnabled = false; };
            button3.Clicked += (sender, e) => { function_on_click(0, 2, ref count, mas, masct); button3.IsEnabled = false; };
            button4.Clicked += (sender, e) => { function_on_click(1, 0, ref count, mas, masct); button4.IsEnabled = false; };
            button5.Clicked += (sender, e) => { function_on_click(1, 1, ref count, mas, masct); button5.IsEnabled = false; };
            button6.Clicked += (sender, e) => { function_on_click(1, 2, ref count, mas, masct); button6.IsEnabled = false; };
            button7.Clicked += (sender, e) => { function_on_click(2, 0, ref count, mas, masct); button7.IsEnabled = false; };
            button8.Clicked += (sender, e) => { function_on_click(2, 1, ref count, mas, masct); button8.IsEnabled = false; };
            button9.Clicked += (sender, e) => { function_on_click(2, 2, ref count, mas, masct); button9.IsEnabled = false; };

            button_new_round.Clicked += (sender, e) => function_default(ref count, mas, ref masct);
        }
        private void function_on_click(int index1, int index2, ref int count, ImageButton[,] mas, char[,] masct)
        {
            mas[index1, index2].Source = (count % 2 == 0) ? "Tac.png" : "Tic.png";

            masct[index1, index2] = (count % 2 == 0) ? 'X' : 'O';

            count++;

            if (masct[0,0] == masct[0, 1] && masct[0, 1] == masct[0, 2] && masct[0, 0] != '0' && masct[0, 1] != '0' && masct[0, 2] != '0')
            {
                function_of_win(count, ref score_first_player, ref score_second_player, mas);
            }
            else if (masct[1, 0] == masct[1, 1] && masct[1, 1] == masct[1, 2] && masct[1, 0] != '0' && masct[1, 1] != '0' && masct[1, 2] != '0')
            {
                function_of_win(count, ref score_first_player, ref score_second_player, mas);
            }
            else if (masct[2, 0] == masct[2, 1] && masct[2, 1] == masct[2, 2] && masct[2, 0] != '0' && masct[2, 1] != '0' && masct[2, 2] != '0')
            {
                function_of_win(count, ref score_first_player, ref score_second_player, mas);
            }
            else if (masct[0, 0] == masct[1, 0] && masct[1, 0] == masct[2, 0] && masct[0, 0] != '0' && masct[1, 0] != '0' && masct[2, 0] != '0')
            {
                function_of_win(count, ref score_first_player, ref score_second_player, mas);
            }
            else if (masct[0, 1] == masct[1, 1] && masct[1, 1] == masct[2, 1] && masct[0, 1] != '0' && masct[1, 1] != '0' && masct[2, 1] != '0')
            {
                function_of_win(count, ref score_first_player, ref score_second_player, mas);
            }
            else if (masct[0, 2] == masct[1, 2] && masct[1, 2] == masct[2, 2] && masct[0, 2] != '0' && masct[1, 2] != '0' && masct[2, 2] != '0')
            {
                function_of_win(count, ref score_first_player, ref score_second_player, mas);
            }
            else if (masct[0, 0] == masct[1, 1] && masct[1, 1] == masct[2, 2] && masct[0, 0] != '0' && masct[1, 1] != '0' && masct[2, 2] != '0')
            {
                function_of_win(count, ref score_first_player, ref score_second_player, mas);
            }
            else if (masct[0, 2] == masct[1, 1] && masct[1, 1] == masct[2, 0] && masct[0, 2] != '0' && masct[1, 1] != '0' && masct[2, 0] != '0')
            {
                function_of_win(count, ref score_first_player, ref score_second_player, mas);
            }
        }
        private void function_of_win(int count, ref int score_first_player, ref int score_second_player, ImageButton[,] mas)
        {
            foreach (var item in mas)
            {
                item.IsEnabled = false;
            }

            button_new_round.IsEnabled = true;

            if (count % 2 == 0)
            {
                score_second_player++;
                first_player_panel.Text = $"Игрок 1: ({score_first_player})";
                second_player_panel.Text = $"Игрок 2: ({score_second_player})";
                DisplayAlert("Tic Tac!", "Игрок 2 победил", "ок");
            }

            else
            {
                score_first_player++;
                first_player_panel.Text = $"Игрок 1: ({score_first_player})";
                second_player_panel.Text = $"Игрок 2: ({score_second_player})";
                DisplayAlert("Tic Tac!", "Игрок 1 победил", "ок");
            }
        }
        private void function_default(ref int count, ImageButton[,] mas, ref char[,] masct)
        {
            count = 0;

            foreach (var item in mas)
            {
                item.Source = null;
                item.IsEnabled = true;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    masct[i, j] = '0';
                }
            }
        }
    }
}