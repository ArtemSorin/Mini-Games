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
    public partial class PaletteGamePage : ContentPage
    {
        public PaletteGamePage()
        {
            InitializeComponent();

            Button[,] mas = new Button[,]
            {
                { button1, button2, button3, button4, button5, button6 },
                { button7, button8, button9, button10, button11, button12 },
                { button13, button14, button15, button16, button17, button18 },
                { button19, button20, button21, button22, button23, button24 },
                { button25, button26, button27, button28, button29, button30 },
                { button31, button32, button33, button34, button35, button36 },
            };

            bool[] bottle_mas = new bool[4];

            for(int i = 0; i < bottle_mas.Length; i++) { bottle_mas[i] = false; }

            blue_button.Clicked += (s, e) => blue_button_function(ref bottle_mas);
            yellow_button.Clicked += (s, e) => yellow_button_function(ref bottle_mas);
            red_button.Clicked += (s, e) => red_button_function(ref bottle_mas);
            green_button.Clicked += (s, e) => green_button_function(ref bottle_mas);
        }
        private void blue_button_function(ref bool[] bottle_mas) { bottle_mas[0] = true; }
        private void yellow_button_function(ref bool[] bottle_mas) { bottle_mas[1] = true; }
        private void red_button_function(ref bool[] bottle_mas) { bottle_mas[2] = true; }
        private void green_button_function(ref bool[] bottle_mas) { bottle_mas[3] = true; }
    }
}