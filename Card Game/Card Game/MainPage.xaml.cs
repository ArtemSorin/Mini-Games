using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Card_Game
{
    public partial class MainPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyBdFcqRkT8IpMLGRLT3zq_oaHFQgMz26Nk";
        public MainPage()
        {
            InitializeComponent();
            button_register.Clicked += (sender, e) => Navigation.PushAsync(new RegisterPage());
        }
        async void loginbutton_Clicked(System.Object sender, System.EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserLoginEmail.Text, UserLoginPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                await Navigation.PushAsync(new GamesPage());
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Уведомление", "Неправильное имя пользователя или пароль", "OK");
            }
        }

    }
}
