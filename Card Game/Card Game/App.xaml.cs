using Card_Game.Services.Implementation;
using Card_Game.Services.Interface;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Card_Game
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Njg1OTAzQDMyMzAyZTMyMmUzMGtEVStWSGpjMWVBY1FIOEVudjFLVVkyb3VBL3BzSC9mSG55ZER4Wm80ZXc9");
            InitializeComponent();

            MainPage = new NavigationPage(new GamesPage());
            DependencyService.Register<IEUserService, UserService>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
