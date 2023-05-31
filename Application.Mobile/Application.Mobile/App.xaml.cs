using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application.Mobile
{
    public partial class App : global::Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
