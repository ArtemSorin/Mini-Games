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
    public partial class CountryLevelSecondPage : ContentPage
    {
        public struct question
        {
            public string image;
            public string var1;
            public string var2;
            public string var3;
            public int answer;
        }
        public List<question> initialQuestLite()
        {
            List<question> questions = new List<question>();
            questions.Add(new question() { image = "country_brazil.png", var1 = "Аргентина", var2 = "Бразилия", var3 = "Чили", answer = 2 });
            questions.Add(new question() { image = "country_china.png", var1 = "Китай", var2 = "Малазия", var3 = "Северная Корея", answer = 1 });
            questions.Add(new question() { image = "country_india.png", var1 = "Индия", var2 = "Тайланд", var3 = "Сингапур", answer = 1 });
            questions.Add(new question() { image = "country_italy.png", var1 = "Португалия", var2 = "Италия", var3 = "Польша", answer = 2 });
            questions.Add(new question() { image = "country_mexico.png", var1 = "Куба", var2 = "Бразилия", var3 = "Мексика", answer = 3 });
            questions.Add(new question() { image = "country_usa.png", var1 = "Канада", var2 = "США", var3 = "Австралия", answer = 2 });

            return questions;
        }
        int answerUpdate(ref List<question> questionsList, int oldQuest, int oldAnswer, ref int countExcelentQuestionAnswers)
        {
            if (oldAnswer == questionsList[oldQuest].answer)
            {
                countExcelentQuestionAnswers++;
            }

            questionsList.RemoveAt(oldQuest);

            Random rnd = new Random();

            if (questionsList.Count != 0)
            {
                int randQuestIndex = rnd.Next(0, questionsList.Count);

                questImage.Source = questionsList[randQuestIndex].image;
                button1.Text = questionsList[randQuestIndex].var1;
                button2.Text = questionsList[randQuestIndex].var2;
                button3.Text = questionsList[randQuestIndex].var3;

                return randQuestIndex;
            }
            else
            {
                return -1;
            }
        }

        void showRes(int countExcelentQuestionAnswers, int allCount, int buttonP)
        {
            questImage.Source = "answerCheck.png";
            button1.Text = $"верно {countExcelentQuestionAnswers} из {allCount}";
            button2.IsVisible = false;
            button3.IsVisible = false;

            if (buttonP == 2)
            {
                //----------------------------------------------------------------------------------
                // здесь повторный запуск этого активити
                //----------------------------------------------------------------------------------
            }
            else if (buttonP == 3)
            {
                //----------------------------------------------------------------------------------
                // здесь выход с этого активити
                //----------------------------------------------------------------------------------
            }
        }
        public CountryLevelSecondPage()
        {
            InitializeComponent();

            RadialGradientBrush radialGradientBrush = new RadialGradientBrush();
            radialGradientBrush.Radius = 1.5;
            radialGradientBrush.GradientStops = new GradientStopCollection()
            {
                new GradientStop(){ Color = Color.FromHex("#6231CC"), Offset = 0 },
                new GradientStop(){ Color = Color.FromHex("#7A4AE0"), Offset = 1 }
            };

            button1.Background = radialGradientBrush;
            button2.Background = radialGradientBrush;
            button3.Background = radialGradientBrush;

            int countExcelentQuestionAnswers = 0;

            List<question> questionsList = initialQuestLite();

            int countAllQuestions = questionsList.Count;

            Random rnd = new Random();

            int randQuestIndex = rnd.Next(0, questionsList.Count);

            questImage.Source = questionsList[randQuestIndex].image;
            button1.Text = questionsList[randQuestIndex].var1;
            button2.Text = questionsList[randQuestIndex].var2;
            button3.Text = questionsList[randQuestIndex].var3;

            int curQuestIndex = randQuestIndex;

            button1.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 1, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                    }
                }
            };

            button2.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 2);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 2, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                    }
                }

            };

            button3.Clicked += (sender, e) =>
            {
                if (curQuestIndex == -1)
                {
                    showRes(countExcelentQuestionAnswers, countAllQuestions, 3);
                }
                else
                {
                    curQuestIndex = answerUpdate(ref questionsList, curQuestIndex, 3, ref countExcelentQuestionAnswers);
                    if (curQuestIndex == -1)
                    {
                        showRes(countExcelentQuestionAnswers, countAllQuestions, 1);
                    }
                }
            };
        }
    }
}