using System;
using Application.MobileClient.Views.Views.Tours;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application.MobileClient
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            Startup.ConfigureServices();
            MainPage = new AppShell();
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
